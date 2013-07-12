package com.jkdh.playerbday13;

import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.widget.Toast;

public class Control {
	private Connection connection;
	private MainActivity activity;

	private String server;
	private int port;

	public Control(MainActivity activity) {
		SharedPreferences settings = PreferenceManager
				.getDefaultSharedPreferences(activity);
		server = settings.getString("setting_server_adress", "127.0.0.1");
		port = Integer.parseInt(settings.getString("setting_server_port",
				"1234"));
		refreshConnection();

		this.activity = activity;
	}

	public void aktualisiere() {
		aktualisiereRemote();
		aktualisierePlaylist();
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

	public void getPlaylistChanged() {
		command("getplaylistchanged");
	}

	private void command(String command) {
		if (!connection.send(command + ":::")) {
			// Toast toast = Toast.makeText(activity, R.string.connectionfailed,
			// Toast.LENGTH_SHORT);
			// toast.show();
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
			final String lenght) {
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

		if (parts[0].equalsIgnoreCase("Connected")) {
			Toast toast = Toast.makeText(activity,
					R.string.connectionestablished, Toast.LENGTH_SHORT);
			toast.show();
		} else if (parts[0].equalsIgnoreCase("getVolume")) {
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
			String[] parts2 = parts[1].split(";;;");
			String title = parts2[0];
			String artist = parts2[1];
			String lenght = parts2[2];

			setCurrentSong(title, artist, lenght);
		} else if (parts[0].equalsIgnoreCase("getPlaylistChanged")) {
			if (parts[1].equalsIgnoreCase("true")) {
				getPlaylist();
			}
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

	public MainActivity getActivity() {
		return activity;
	}

	public void refreshConnection() {
		if (connection != null) {
			connection.close();
			connection.cancel(true);
		}

		connection = new Connection(this, server, port);
		connection.execute();
	}

	public void closeConnection() {
		connection.close();
	}

}
