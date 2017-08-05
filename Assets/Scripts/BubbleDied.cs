using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDied : MonoBehaviour {
	public Animator bubble;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Spike"))
		{
			bubble.SetInteger("State", 1);
			Handheld.Vibrate();
            if (Social.localUser.authenticated)
            {
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_pop_goes_the_weasel, 100.0f, (bool success) => { Debug.Log("Success"); });

                if (SpikeGeneration.score == 15)
                {
                    PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_up_up_and_away, 100.0f, (bool success) => { Debug.Log("Success"); });
                }
            }

			if (PlayGamesPlatform.Instance.localUser.authenticated)
			{
				PlayGamesPlatform.Instance.ReportScore(SpikeGeneration.score,
					"CgkI2oLCi_MWEAIQBg", (bool success) => {
						Debug.Log("(Lollygagger) Leaderboard update success: " + success);
					});

				// NEW: add this function call.
				// Read saved game data and update
				WriteUpdatedScore();
			}

			if (SpikeGeneration.score > PlayerPrefs.GetInt("HighScoreSave"))
			{
				PlayerPrefs.SetInt("HighScoreSave", SpikeGeneration.score);
			}
		}
		AdManager.Instance.ShowVideo();
	}

	public void ReadSavedGame(string filename, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
	{
		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
		savedGameClient.OpenWithAutomaticConflictResolution(
			filename,
			DataSource.ReadCacheOrNetwork,
			ConflictResolutionStrategy.UseLongestPlaytime,
			callback);
	}

	public void WriteSavedGame(ISavedGameMetadata game, byte[] savedData, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
	{
		SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder()
			.WithUpdatedPlayedTime(TimeSpan.FromMinutes(game.TotalTimePlayed.Minutes + 1))
			.WithUpdatedDescription("Saved at: " + System.DateTime.Now);

		SavedGameMetadataUpdate updatedMetadata = builder.Build();

		ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
		savedGameClient.CommitUpdate(game, updatedMetadata, savedData, callback);
	}

public void WriteUpdatedScore()
{
	// Local variable
	ISavedGameMetadata currentGame = null;

	// CALLBACK: Handle the result of a write
	Action<SavedGameRequestStatus, ISavedGameMetadata> writeCallback =
	(SavedGameRequestStatus status, ISavedGameMetadata game) => {
		Debug.Log("(Lollygagger) Saved Game Write: " + status.ToString());
	};

	// CALLBACK: Handle the result of a binary read
	Action<SavedGameRequestStatus, byte[]> readBinaryCallback =
	(SavedGameRequestStatus status, byte[] data) => {
		Debug.Log("(Lollygagger) Saved Game Binary Read: " + status.ToString());
		if (status == SavedGameRequestStatus.Success)
		{
				// Read score from the Saved Game
				int score = SpikeGeneration.score;
			try
			{
				string scoreString = System.Text.Encoding.UTF8.GetString(data);
				score = Convert.ToInt32(scoreString);
			}
			catch (Exception e)
			{
				Debug.Log("Saved Game Write: convert exception");
			}
			string newScoreString = Convert.ToString(score);
			byte[] newData = System.Text.Encoding.UTF8.GetBytes(newScoreString);
			// Write new data
			Debug.Log("(Lollygagger) Old Score: " + score.ToString());
			Debug.Log("(Lollygagger) New Score: " + score.ToString());
			WriteSavedGame(currentGame, newData, writeCallback);
		}
	};

	// CALLBACK: Handle the result of a read, which should return metadata
	Action<SavedGameRequestStatus, ISavedGameMetadata> readCallback =
	(SavedGameRequestStatus status, ISavedGameMetadata game) => {
		Debug.Log("(Lollygagger) Saved Game Read: " + status.ToString());
		if (status == SavedGameRequestStatus.Success)
		{
				// Read the binary game data
				currentGame = game;
			PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(game,
												readBinaryCallback);
		}
	};

	// Read the current data and kick off the callback chain
	Debug.Log("(Lollygagger) Saved Game: Reading");
	ReadSavedGame("file_total_hits", readCallback);
}

}
