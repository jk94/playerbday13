package com.jkdh.playerbday13;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

public class PlaylistAdapter extends ArrayAdapter<PlaylistItem> {
	private Context c;
	private ArrayList<PlaylistItem> items;
	private final static int ID = R.layout.listitem_playlist;

	public PlaylistAdapter(Context context, ArrayList<PlaylistItem> objects) {
		super(context, ID, objects);
		c = context;
		items = objects;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		RelativeLayout v = (RelativeLayout) convertView;
		if (v == null) {
			LayoutInflater vi = (LayoutInflater) c
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			v = (RelativeLayout) vi.inflate(ID, null);
		}

		TextView title = (TextView) v.findViewById(R.id.playlistitem_title);
		TextView artist = (TextView) v.findViewById(R.id.playlistitem_artist);
		TextView lenght = (TextView) v.findViewById(R.id.playlistitem_lenght);
		ImageView image = (ImageView) v.findViewById(R.id.playlistitem_image);

		if (title != null) {
			title.setText(items.get(position).getTitle());
		}
		if (artist != null) {
			artist.setText(items.get(position).getArtist());
		}
		if (lenght != null) {
			lenght.setText(items.get(position).getLenght());
		}
		if (image != null && items.get(position).getImage() != null) {
			image.setImageDrawable(items.get(position).getImage());
		}
		return v;
	}
}
