package com.gaston.desktop;

import com.badlogic.gdx.backends.lwjgl.LwjglApplication;
import com.badlogic.gdx.backends.lwjgl.LwjglApplicationConfiguration;
import com.gaston.Configuration;
import com.gaston.Mole;

public class DesktopLauncher {
	public static void main (String[] arg) {
		LwjglApplicationConfiguration config = new LwjglApplicationConfiguration();
		config.width = Configuration.DISPLAY_WIDTH();
		config.height = Configuration.DISPLAY_HEIGHT();
		new LwjglApplication(new Mole(), config);
	}
}
