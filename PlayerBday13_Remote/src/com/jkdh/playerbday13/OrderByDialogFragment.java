package com.jkdh.playerbday13;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;

public class OrderByDialogFragment extends DialogFragment implements
		OnClickListener {

	private OrderByDialogListener listener;

	@Override
	public Dialog onCreateDialog(Bundle savedInstanceState) {

		AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
		builder.setTitle(R.string.title_orderby).setCancelable(true)
				.setItems(R.array.orderby_options, this);

		return builder.create();
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			listener = (OrderByDialogListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString()
					+ " must implement OrderByDialogListener");
		}
	}

	@Override
	public void onClick(DialogInterface dialog, int which) {
		listener.onOrderByDialogSelected(which);
	}

	public interface OrderByDialogListener {
		public void onOrderByDialogSelected(int type);
	}
}