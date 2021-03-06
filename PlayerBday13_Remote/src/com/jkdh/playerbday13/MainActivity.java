package com.jkdh.playerbday13;

import java.util.ArrayList;
import java.util.Locale;

import android.app.ActionBar;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.ExpandableListView;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.TextView;

import com.jkdh.playerbday13.OrderByDialogFragment.OrderByDialogListener;

public class MainActivity extends FragmentActivity implements
		ActionBar.TabListener, OrderByDialogListener {

	/**
	 * The {@link android.support.v4.view.PagerAdapter} that will provide
	 * fragments for each of the sections. We use a
	 * {@link android.support.v4.app.FragmentPagerAdapter} derivative, which
	 * will keep every loaded fragment in memory. If this becomes too memory
	 * intensive, it may be best to switch to a
	 * {@link android.support.v4.app.FragmentStatePagerAdapter}.
	 */
	SectionsPagerAdapter mSectionsPagerAdapter;

	/**
	 * The {@link ViewPager} that will host the section contents.
	 */
	ViewPager mViewPager;

	private static Control control;

	public Control getControl() {
		return control;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		// Set up the action bar.
		final ActionBar actionBar = getActionBar();
		actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

		// Create the adapter that will return a fragment for each of the three
		// primary sections of the app.
		mSectionsPagerAdapter = new SectionsPagerAdapter(
				getSupportFragmentManager());

		// Set up the ViewPager with the sections adapter.
		mViewPager = (ViewPager) findViewById(R.id.pager);
		mViewPager.setAdapter(mSectionsPagerAdapter);

		// When swiping between different sections, select the corresponding
		// tab. We can also use ActionBar.Tab#select() to do this if we have
		// a reference to the Tab.
		mViewPager
				.setOnPageChangeListener(new ViewPager.SimpleOnPageChangeListener() {
					@Override
					public void onPageSelected(int position) {
						actionBar.setSelectedNavigationItem(position);
					}
				});

		// For each of the sections in the app, add a tab to the action bar.
		for (int i = 0; i < mSectionsPagerAdapter.getCount(); i++) {
			// Create a tab with text corresponding to the page title defined by
			// the adapter. Also specify this Activity object, which implements
			// the TabListener interface, as the callback (listener) for when
			// this tab is selected.
			actionBar.addTab(actionBar.newTab()
					.setText(mSectionsPagerAdapter.getPageTitle(i))
					.setTabListener(this));
		}

		control = new Control(this);
	}

	@Override
	protected void onStop() {
		control.closeConnection();
		super.onStop();
	}

	@Override
	public void onTabSelected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
		// When the given tab is selected, switch to the corresponding page in
		// the ViewPager.
		mViewPager.setCurrentItem(tab.getPosition());
	}

	@Override
	public void onTabUnselected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
	}

	@Override
	public void onTabReselected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
	}

	@Override
	public void onOrderByDialogSelected(int type) {
	}

	public void aktualisiereRemote() {
		control.aktualisiereRemote();
	}

	public void aktualisierePlaylist() {
		control.aktualisierePlaylist();
	}

	/**
	 * A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	 * one of the sections/tabs/pages.
	 */
	public class SectionsPagerAdapter extends FragmentPagerAdapter {

		public SectionsPagerAdapter(FragmentManager fm) {
			super(fm);
		}

		@Override
		public Fragment getItem(int position) {
			Fragment fragment;
			// Bundle args = new Bundle();
			// args.putInt(DummySectionFragment.ARG_SECTION_NUMBER, position +
			// 1);
			// fragment.setArguments(args);
			switch (position) {
			case 0:
				fragment = new RemoteSectionFragment();
				break;
			case 1:
				fragment = new PlaylistSectionFragment();
				break;
			case 2:
				fragment = new LibrarySectionFragment();
				break;
			default:
				fragment = null;
			}

			return fragment;
		}

		@Override
		public int getCount() {
			// return 3;
			return 2;
		}

		@Override
		public CharSequence getPageTitle(int position) {
			Locale l = Locale.getDefault();
			switch (position) {
			case 0:
				return getString(R.string.title_remote).toUpperCase(l);
			case 1:
				return getString(R.string.title_playlist).toUpperCase(l);
			case 2:
				return getString(R.string.title_library).toUpperCase(l);
			}
			return null;
		}
	}

	public static class RemoteSectionFragment extends Fragment {

		@Override
		public void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);
			setHasOptionsMenu(true);
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_remote,
					container, false);

			MainActivity activity = (MainActivity) getActivity();
			final Control control = activity.getControl();

			final ImageButton previous = (ImageButton) rootView
					.findViewById(R.id.remote_previous);
			final ImageButton next = (ImageButton) rootView
					.findViewById(R.id.remote_next);
			final CheckBox play = (CheckBox) rootView
					.findViewById(R.id.remote_play);
			final CheckBox mute = (CheckBox) rootView
					.findViewById(R.id.checkBox_mute);
			final CheckBox shuffle = (CheckBox) rootView
					.findViewById(R.id.checkbox_shuffle);
			final SeekBar volume = (SeekBar) rootView
					.findViewById(R.id.remote_seekbar_volume);

			previous.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					control.previous();
				}
			});

			next.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					control.next();
				}
			});

			play.setOnCheckedChangeListener(new OnCheckedChangeListener() {

				@Override
				public void onCheckedChanged(CompoundButton buttonView,
						boolean isChecked) {
					if (isChecked) {
						control.play();
					} else {
						control.pause();
					}
				}
			});

			mute.setOnCheckedChangeListener(new OnCheckedChangeListener() {

				@Override
				public void onCheckedChanged(CompoundButton buttonView,
						boolean isChecked) {
					volume.setEnabled(isChecked);
					if (isChecked) {
						control.unmute();
					} else {
						control.mute();
					}
				}
			});

			shuffle.setOnCheckedChangeListener(new OnCheckedChangeListener() {

				@Override
				public void onCheckedChanged(CompoundButton buttonView,
						boolean isChecked) {
					if (isChecked) {
						control.shuffleOn();
					} else {
						control.shuffleOff();
					}
				}
			});

			volume.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {

				@Override
				public void onStopTrackingTouch(SeekBar seekBar) {
					control.volume(seekBar.getProgress());
				}

				@Override
				public void onStartTrackingTouch(SeekBar seekBar) {
				}

				@Override
				public void onProgressChanged(SeekBar seekBar, int progress,
						boolean fromUser) {
				}
			});

			return rootView;
		}

		@Override
		public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
			super.onCreateOptionsMenu(menu, inflater);
			inflater.inflate(R.menu.menu_remote, menu);

			((MainActivity) getActivity()).aktualisiereRemote();
		}

		@Override
		public boolean onOptionsItemSelected(MenuItem item) {
			switch (item.getItemId()) {
			case R.id.settings:
				Intent i = new Intent(this.getActivity(),
						SettingsActivity.class);
				startActivity(i);
				break;
			// case R.id.refresh:
			// control.refreshConnection();
			// break;
			}
			return true;
		}
	}

	private static ArrayList<PlaylistItem> playlistitems;
	private static PlaylistAdapter playlistadapter;

	public static class PlaylistSectionFragment extends Fragment {

		Context context;

		@Override
		public void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);
			setHasOptionsMenu(true);
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_playlist,
					container, false);

			ListView list = (ListView) rootView
					.findViewById(R.id.playlist_listView);

			playlistitems = new ArrayList<PlaylistItem>();

			playlistadapter = new PlaylistAdapter(inflater.getContext(),
					playlistitems);

			list.setAdapter(playlistadapter);

			final Control control = ((MainActivity) getActivity()).getControl();

			list.setOnItemClickListener(new OnItemClickListener() {

				@Override
				public void onItemClick(AdapterView<?> view, View arg1,
						int pos, long arg3) {
					control.play(pos);
				}
			});

			return rootView;
		}

		@Override
		public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
			super.onCreateOptionsMenu(menu, inflater);
			inflater.inflate(R.menu.menu_playlist, menu);

			((MainActivity) getActivity()).aktualisierePlaylist();
		}
	}

	public static class LibrarySectionFragment extends Fragment {

		Context context;

		@Override
		public void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);
			setHasOptionsMenu(true);
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_library,
					container, false);

			ExpandableListView list = (ExpandableListView) rootView
					.findViewById(R.id.library_listView);

			ArrayList<LibraryGroupItem> groups = new ArrayList<LibraryGroupItem>();
			groups.add(new LibraryGroupItem("Daft Punk", "", null));
			groups.add(new LibraryGroupItem("Taio Cruz", "", null));
			groups.add(new LibraryGroupItem("Blabla", "", null));

			ArrayList<ArrayList<LibraryItem>> items = new ArrayList<ArrayList<LibraryItem>>();

			items.add(new ArrayList<LibraryItem>());
			items.add(new ArrayList<LibraryItem>());
			items.add(new ArrayList<LibraryItem>());

			items.get(0).add(
					new LibraryItem("Get Lucky", "Daft Punk", "55", null,
							groups.get(0)));
			items.get(0).add(
					new LibraryItem("Lose Yourself To Dance", "Daft Punk",
							"55", null, groups.get(0)));
			items.get(1).add(
					new LibraryItem("Shotcaller", "Taio Cruz", "75", null,
							groups.get(1)));
			items.get(2).add(
					new LibraryItem("Blabla", "blub", "7750", null, groups
							.get(2)));
			items.get(2).add(
					new LibraryItem("Und Hier noch ein extra laaaaaanges Lied",
							"blub", "7750099", null, groups.get(2)));

			LibraryAdapter adapter = new LibraryAdapter(inflater.getContext(),
					groups, items);

			// list.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
			//
			// list.setMultiChoiceModeListener(new MultiChoiceModeListener() {
			//
			// @Override
			// public void onItemCheckedStateChanged(ActionMode mode,
			// int position, long id, boolean checked) {
			// // Here you can do something when items are
			// // selected/de-selected,
			// // such as update the title in the CAB
			// }
			//
			// @Override
			// public boolean onActionItemClicked(ActionMode mode,
			// MenuItem item) {
			// // Respond to clicks on the actions in the CAB
			// switch (item.getItemId()) {
			// // case R.id.menu_delete:
			// // deleteSelectedItems();
			// // mode.finish(); // Action picked, so close the CAB
			// // return true;
			// default:
			// return false;
			// }
			// }
			//
			// @Override
			// public boolean onCreateActionMode(ActionMode mode, Menu menu) {
			// // Inflate the menu for the CAB
			// MenuInflater inflater = mode.getMenuInflater();
			// inflater.inflate(R.menu.contextmenu_library, menu);
			// return true;
			// }
			//
			// @Override
			// public void onDestroyActionMode(ActionMode mode) {
			// // Here you can make any necessary updates to the activity
			// // when
			// // the CAB is removed. By default, selected items are
			// // deselected/unchecked.
			// }
			//
			// @Override
			// public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
			// // Here you can perform updates to the CAB due to
			// // an invalidate() request
			// return false;
			// }
			// });

			list.setAdapter(adapter);

			return rootView;
		}

		@Override
		public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
			super.onCreateOptionsMenu(menu, inflater);
			inflater.inflate(R.menu.menu_library, menu);
		}

		@Override
		public boolean onOptionsItemSelected(MenuItem item) {
			switch (item.getItemId()) {
			case R.id.orderby:
				DialogFragment dialog = new OrderByDialogFragment();
				dialog.show(getActivity().getSupportFragmentManager(),
						"OrderByDialogFragment");
				break;
			}
			return true;
		}

	}

	public void setVolume(int i) {
		SeekBar volume = (SeekBar) findViewById(R.id.remote_seekbar_volume);
		if (volume != null)
			volume.setProgress(i);
	}

	public void setPlay(boolean b) {
		CheckBox play = (CheckBox) findViewById(R.id.remote_play);
		if (play != null)
			play.setChecked(b);
	}

	public void setMute(boolean b) {
		CheckBox mute = (CheckBox) findViewById(R.id.checkBox_mute);
		if (mute != null)
			mute.setChecked(b);
	}

	public void setShuffle(boolean b) {
		CheckBox shuffle = (CheckBox) findViewById(R.id.checkbox_shuffle);
		if (shuffle != null)
			shuffle.setChecked(b);
	}

	public void setCurrentSong(String title, String artist, String lenght) {
		TextView tv_title = (TextView) findViewById(R.id.remote_title);
		if (tv_title != null)
			tv_title.setText(title);
		TextView tv_artist = (TextView) findViewById(R.id.remote_artist);
		if (tv_title != null)
			tv_artist.setText(artist);
		TextView tv_lenght = (TextView) findViewById(R.id.remote_lenght);
		if (tv_lenght != null)
			tv_lenght.setText(lenght);
	}

	public void setPlaylist(PlaylistItem[] items) {
		playlistitems.clear();
		for (int i = 0; i < items.length; i++) {
			playlistitems.add(items[i]);
		}
		playlistadapter.notifyDataSetChanged();
	}
}
