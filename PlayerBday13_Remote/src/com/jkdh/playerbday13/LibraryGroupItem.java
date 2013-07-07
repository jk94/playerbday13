package com.jkdh.playerbday13;

import android.graphics.drawable.Drawable;

public class LibraryGroupItem {

	private String title;
	private String subtitle;
	private Drawable image;

	public LibraryGroupItem(String title, String subtitle, Drawable image) {
		super();
		this.title = title;
		this.subtitle = subtitle;
		this.image = image;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getSubtitle() {
		return subtitle;
	}

	public void setSubtitle(String subtitle) {
		this.subtitle = subtitle;
	}

	public Drawable getImage() {
		return image;
	}

	public void setImage(Drawable image) {
		this.image = image;
	}

}
