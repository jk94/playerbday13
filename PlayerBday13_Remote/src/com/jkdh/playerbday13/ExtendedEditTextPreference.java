package com.jkdh.playerbday13;

import android.content.Context;
import android.preference.EditTextPreference;
import android.util.AttributeSet;

public class ExtendedEditTextPreference extends EditTextPreference {
	public ExtendedEditTextPreference(Context context) {
		super(context);
	}

	public ExtendedEditTextPreference(Context context, AttributeSet attrs) {
		super(context, attrs);
	}

	@Override
	public void setText(String value) {
		super.setText(value);
		setSummary(value);
	}
}