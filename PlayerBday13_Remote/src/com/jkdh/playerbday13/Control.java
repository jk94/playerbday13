package com.jkdh.playerbday13;

public class Control {
	private Connection connection;

	public Control() {
		connection = new Connection(this, "192.168.178.22", 1234);
		connection.execute();
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
			command("volume " + i);
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
		connection.send(command);
	}

	public void response(String s) {
		System.out.println(s);
	}

}
