package com.jkdh.playerbday13;

import java.util.ArrayList;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.CheckBox;

public class ExtendedCheckBox extends CheckBox {

	private ArrayList<OnCheckedChangeToSendListener> listeners = new ArrayList<ExtendedCheckBox.OnCheckedChangeToSendListener>();

	public ExtendedCheckBox(Context context) {
		super(context);
		listeners = new ArrayList<ExtendedCheckBox.OnCheckedChangeToSendListener>();
	}

	public ExtendedCheckBox(Context context, AttributeSet attrs) {
		super(context, attrs);
		listeners = new ArrayList<ExtendedCheckBox.OnCheckedChangeToSendListener>();
	}

	public ExtendedCheckBox(Context context, AttributeSet attrs, int defStyle) {
		super(context, attrs, defStyle);
		listeners = new ArrayList<ExtendedCheckBox.OnCheckedChangeToSendListener>();
	}

	public void setChecked(boolean isChecked) {
		setChecked(isChecked, true);
	}

	public void setChecked(boolean isChecked, boolean send) {
		super.setChecked(isChecked);
		if (listeners != null) {
			if (send) {
				for (int i = 0; i < listeners.size(); i++) {
					if (listeners.get(i) != null) {
						listeners.get(i).onCheckedChanged();
					}
				}
			}
		}
	}

	public void setOnCheckedChangeToSendListener(
			OnCheckedChangeToSendListener listener) {
		listeners.add(listener);
	}

	public interface OnCheckedChangeToSendListener {
		public void onCheckedChanged();
	}
}
