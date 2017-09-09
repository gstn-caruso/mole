package com.gaston.scenario

import ar.com.pablitar.libgdx.commons.traits.RectangularPositioned
import com.badlogic.gdx.math.Vector2
import com.gaston.Configuration

class Ground extends RectangularPositioned {
  position = new Vector2(0, 0)
  override val width: Float = Configuration.DISPLAY_WIDTH * 2
  override val height = 15f
}
