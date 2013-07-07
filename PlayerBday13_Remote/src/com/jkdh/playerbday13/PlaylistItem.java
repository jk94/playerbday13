package com.jkdh.playerbday13;

import java.text.DecimalFormat;

import android.graphics.drawable.Drawable;

public class PlaylistItem {
	private String title;
	private String artist;
	private int lenght;
	private Drawable image;

	public PlaylistItem(String title, String artist, int lenght, Drawable image) {
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
		String s = "";
		int stunden = 0;
		int minuten = 0;
		int sekunden = 0;

		DecimalFormat df = new DecimalFormat("00");

		stunden = (int) Math.floor(lenght / 3600);
		minuten = (int) Math.floor((lenght - (stunden * 3600)) / 60);
		sekunden = (int) Math.floor(lenght % 60);

		if (stunden > 0) {
			s = stunden + ":" + df.format(minuten) + ":" + df.format(sekunden);
		} else {
			s += minuten + ":" + df.format(sekunden);
		}

		return s;
	}

	public void setLenght(int lenght) {
		this.lenght = lenght;
	}

	public Drawable getImage() {
		return image;
	}

	public void setImage(Drawable image) {
		this.image = image;
	}

}
