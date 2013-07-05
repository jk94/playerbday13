package com.jkdh.playerbday13;

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

	public int getLenght() {
		return lenght;
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
