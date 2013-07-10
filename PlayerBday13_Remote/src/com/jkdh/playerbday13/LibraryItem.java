package com.jkdh.playerbday13;

import android.graphics.drawable.Drawable;

public class LibraryItem extends PlaylistItem {

	private LibraryGroupItem group;

	public LibraryItem(String title, String artist, String lenght,
			Drawable image, LibraryGroupItem group) {
		super(title, artist, lenght, image);
		this.group = group;
	}

	public LibraryGroupItem getGroup() {
		return group;
	}

	public void setGroup(LibraryGroupItem group) {
		this.group = group;
	}

}
