package com.jkdh.playerbday13;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.URL;

import android.os.AsyncTask;

public class Connection extends AsyncTask<URL, Integer, Long> {
	private Socket socket;
	private PrintWriter out;
	private BufferedReader in;

	private String server;
	private int port;

	private Control control;

	public Connection(Control control, String server, int port) {
		this.server = server;
		this.port = port;
		this.control = control;
	}

	@Override
	protected Long doInBackground(URL... params) {
		try {
			socket = null;
			socket = new Socket(server, port);

			in = new BufferedReader(new InputStreamReader(
					socket.getInputStream()));
			out = new PrintWriter(socket.getOutputStream());

			while (socket.isConnected()) {
				control.response(in.readLine());
				System.out.println("readLine");
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	public boolean send(String s) {
		if (out != null) {
			out.write(s);
			out.flush();
			return true;
		} else {
			return false;
		}
	}
}
