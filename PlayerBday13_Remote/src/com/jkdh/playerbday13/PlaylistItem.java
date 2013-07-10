package com.jkdh.playerbday13;

import android.graphics.drawable.Drawable;

public class PlaylistItem {
	private String title;
	private String artist;
	private String lenght;
	private Drawable image;

	public PlaylistItem(String title, String artist, String lenght,
			Drawable image) {
		super();
		this.title = title;
		this.artist = artist;
		this.lenght = lenght;
		this.image = image;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getArtist() {
		return artist;
	}

	public void setArtist(String artist) {
		this.artist = artist;
	}

	public String getLenght() {
		return lenght;
	}

	public void setLenght(String lenght) {
		this.lenght = lenght;
	}

	public Drawable getImage() {
		return image;
	}

	public void setImage(Drawable image) {
		this.image = image;
	}

	// public static String getLenghtStringByInteger(int i) {
	// String s = "";
	// int stunden = 0;
	// int minuten = 0;
	// int sekunden = 0;
	//
	// DecimalFormat df = new DecimalFormat("00");
	//
	// stunden = (int) Math.floor(i / 3600);
	// minuten = (int) Math.floor((i - (stunden * 3600)) / 60);
	// sekunden = (int) Math.floor(i % 60);
	//
	// if (stunden > 0) {
	// s = stunden + ":" + df.format(minuten) + ":" + df.format(sekunden);
	// } else {
	// s += minuten + ":" + df.format(sekunden);
	// }
	//
	// return s;
	// }

}
