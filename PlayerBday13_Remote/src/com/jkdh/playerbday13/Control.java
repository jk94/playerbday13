package com.jkdh.playerbday13;

import android.widget.Toast;

public class Control {
	private Connection connection;
	private MainActivity activity;

	public Control(MainActivity activity) {
		connection = new Connection(this, "192.168.178.22", 1234);
		connection.execute();
		this.activity = activity;
	}

	public void aktualisiereRemote() {
		isPlaying();
		isMute();
		isShuffle();
		getCurrentSong();
		getVolume();
	}

	public void playpause() {
		command("playpause");
	}

	public void next() {
		command("next");
	}

	public void previous() {
		command("previous");
	}

	public void mute() {
		command("mute");
	}

	public void unmute() {
		command("unmute");
	}

	public void volume(int i) {
		if (i <= 100 && i >= 0) {
			command("volume:::" + i);
		}
	}

	public void shuffleOn() {
		command("shuffleOn");
	}

	public void shuffleOff() {
		command("shuffleOff");
	}

	public void isPlaying() {
		command("isPlaying");
	}

	public void isMute() {
		command("isMute");
	}

	public void isShuffle() {
		command("isShuffle");
	}

	public void getVolume() {
		command("getVolume");
	}

	public void getCurrentSong() {
		command("getCurrentSong");
	}

	public void getPlaylist() {
		command("getPlaylist");
	}

	private void command(String command) {
		if (!connection.send(command)) {
			Toast toast = Toast.makeText(activity, R.string.connectionfailed,
					Toast.LENGTH_LONG);
			toast.show();
		}
	}

	private void setVolume(final int i) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setVolume(i);
			}
		});
	}

	private void setPlay(final boolean b) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setPlay(b);
			}
		});
	}

	private void setMute(final boolean b) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setMute(b);
			}
		});
	}

	private void setShuffle(final boolean b) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setShuffle(b);
			}
		});
	}

	private void setCurrentSong(final String title, final String artist,
			final int lenght) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setCurrentSong(title, artist, lenght);
			}
		});
	}

	public void response(String s) {
		System.out.println(s);

		String[] parts = s.split(":::");

		if (parts[0].equalsIgnoreCase("volume")) {
			setVolume(Integer.parseInt(parts[1].trim()));
		} else if (parts[0].equalsIgnoreCase("play")) {
			setPlay(false);
		} else if (parts[0].equalsIgnoreCase("pause")) {
			setPlay(true);
		} else if (parts[0].equalsIgnoreCase("mute")) {
			setMute(false);
		} else if (parts[0].equalsIgnoreCase("unmute")) {
			setMute(true);
		} else if (parts[0].equalsIgnoreCase("shuffleOn")) {
			setShuffle(true);
		} else if (parts[0].equalsIgnoreCase("shuffleOff")) {
			setShuffle(false);
		} else if (parts[0].equalsIgnoreCase("CurrentSong")) {
			setCurrentSong(parts[1].trim(), parts[2].trim(),
					Integer.parseInt(parts[3].trim()));
		}

	}

}
