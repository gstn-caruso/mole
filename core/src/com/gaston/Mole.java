package com.gaston;

import com.badlogic.gdx.Game;
import com.gaston.screens.GameScreen;

public class Mole extends Game {

	@Override
	public void create () {
		setScreen(new GameScreen());
	}
}
