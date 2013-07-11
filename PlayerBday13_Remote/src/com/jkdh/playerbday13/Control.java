package com.jkdh.playerbday13;

import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.widget.Toast;

public class Control {
	private Connection connection;
	private MainActivity activity;

	public Control(MainActivity activity) {
		SharedPreferences settings = PreferenceManager
				.getDefaultSharedPreferences(activity);
		String server = settings
				.getString("setting_server_adress", "127.0.0.1");
		int port = Integer.parseInt(settings.getString("setting_server_port",
				"1234"));

		connection = new Connection(this, server, port);
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

	public void aktualisierePlaylist() {
		getPlaylist();
	}

	public void play(int pos) {
		command("play:::" + pos);
	}

	public void play() {
		command("play");
	}

	public void pause() {
		command("pause");
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
		command("shuffleon");
	}

	public void shuffleOff() {
		command("shuffleoff");
	}

	public void isPlaying() {
		command("isplaying");
	}

	public void isMute() {
		command("ismute");
	}

	public void isShuffle() {
		command("isshuffle");
	}

	public void getVolume() {
		command("getvolume");
	}

	public void getCurrentSong() {
		command("getcurrentsong");
	}

	public void getPlaylist() {
		command("getplaylist");
	}

	private void command(String command) {
		if (!connection.send(command + ":::")) {
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

	private void setPlaylist(final PlaylistItem[] items) {
		activity.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				activity.setPlaylist(items);
			}
		});
	}

	public void response(String s) {
		System.out.println(s);

		String[] parts = s.split(":::");

		if (parts[0].equalsIgnoreCase("getVolume")) {
			setVolume(Integer.parseInt(parts[1].trim()));
		} else if (parts[0].equalsIgnoreCase("isPlaying")) {
			if (parts[1].equalsIgnoreCase("true")) {
				setPlay(true);
			} else if (parts[1].equalsIgnoreCase("false")) {
				setPlay(false);
			}
		} else if (parts[0].equalsIgnoreCase("isMute")) {
			if (parts[1].equalsIgnoreCase("true")) {
				setMute(false);
			} else if (parts[1].equalsIgnoreCase("false")) {
				setMute(true);
			}
		} else if (parts[0].equalsIgnoreCase("isShuffle")) {
			if (parts[1].equalsIgnoreCase("true")) {
				setShuffle(true);
			} else if (parts[1].equalsIgnoreCase("false")) {
				setShuffle(false);
			}
		} else if (parts[0].equalsIgnoreCase("getCurrentSong")) {
			setCurrentSong(parts[1].trim(), parts[2].trim(),
					Integer.parseInt(parts[3].trim()));
		} else if (parts[0].equalsIgnoreCase("getPlaylist")) {
			PlaylistItem[] items = new PlaylistItem[parts.length - 1];

			for (int i = 1; i < parts.length; i++) {
				String[] parts2 = parts[i].split(";;;");
				String title = parts2[0];
				String artist = parts2[1];
				String lenght = parts2[2];

				items[i - 1] = new PlaylistItem(title, artist, lenght, null);
			}

			setPlaylist(items);
		}

	}

}
