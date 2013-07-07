package com.jkdh.playerbday13;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class LibraryAdapter extends BaseExpandableListAdapter {
	@Override
	public boolean areAllItemsEnabled() {
		return true;
	}

	private Context context;
	private ArrayList<LibraryGroupItem> groups;
	private ArrayList<ArrayList<LibraryItem>> children;

	public LibraryAdapter(Context context, ArrayList<LibraryGroupItem> groups,
			ArrayList<ArrayList<LibraryItem>> children) {
		this.context = context;
		this.groups = groups;
		this.children = children;
	}

	public void addItem(LibraryItem item) {
		if (!groups.contains(item.getGroup())) {
			groups.add(item.getGroup());
		}
		int index = groups.indexOf(item.getGroup());
		if (children.size() < index + 1) {
			children.add(new ArrayList<LibraryItem>());
		}
		children.get(index).add(item);
	}

	@Override
	public Object getChild(int groupPosition, int childPosition) {
		return children.get(groupPosition).get(childPosition);
	}

	@Override
	public long getChildId(int groupPosition, int childPosition) {
		return childPosition;
	}

	@Override
	public View getChildView(int groupPosition, int childPosition,
			boolean isLastChild, View convertView, ViewGroup parent) {
		LibraryItem item = (LibraryItem) getChild(groupPosition, childPosition);
		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.listitem_library_child, null);
		}

		TextView title = (TextView) convertView
				.findViewById(R.id.librarychilditem_title);
		title.setText(item.getTitle());

		TextView artist = (TextView) convertView
				.findViewById(R.id.librarychilditem_artist);
		artist.setText(item.getArtist());

		TextView lenght = (TextView) convertView
				.findViewById(R.id.librarychilditem_lenght);
		lenght.setText(item.getLenght());

		return convertView;
	}

	@Override
	public int getChildrenCount(int groupPosition) {
		return children.get(groupPosition).size();
	}

	@Override
	public Object getGroup(int groupPosition) {
		return groups.get(groupPosition);
	}

	@Override
	public int getGroupCount() {
		return groups.size();
	}

	@Override
	public long getGroupId(int groupPosition) {
		return groupPosition;
	}

	@Override
	public View getGroupView(int groupPosition, boolean isExpanded,
			View convertView, ViewGroup parent) {
		LibraryGroupItem group = (LibraryGroupItem) getGroup(groupPosition);
		if (convertView == null) {
			LayoutInflater infalInflater = (LayoutInflater) context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = infalInflater.inflate(
					R.layout.listitem_library_group, null);
		}

		TextView title = (TextView) convertView
				.findViewById(R.id.librarygroupitem_title);
		title.setText(group.getTitle());

		TextView subtitle = (TextView) convertView
				.findViewById(R.id.librarygroupitem_subtitle);
		subtitle.setText(group.getSubtitle());

		((ImageView) convertView.findViewById(R.id.librarygroupitem_indicator))
				.setImageResource(isExpanded ? R.drawable.navigation_collapse
						: R.drawable.navigation_expand);

		return convertView;
	}

	@Override
	public boolean hasStableIds() {
		return true;
	}

	@Override
	public boolean isChildSelectable(int arg0, int arg1) {
		return true;
	}
}