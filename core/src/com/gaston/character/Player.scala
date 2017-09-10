package com.gaston.character

import ar.com.pablitar.libgdx.commons.extensions.ShapeExtensions._
import ar.com.pablitar.libgdx.commons.traits.{RectangularPositioned, SpeedBehaviour}
import com.badlogic.gdx.Gdx
import com.badlogic.gdx.Input.Keys
import com.badlogic.gdx.math.Vector2
import com.gaston.scenario.Ground

class Player extends RectangularPositioned with SpeedBehaviour {
  val basePlayerSpeedMagnitude = 800

  position = new Vector2(10, 300)
  override val width = 15f
  override val height = 80f
  var acceleration = new Vector2(0, -250f)

  def update(delta: Float, ground: Ground) = {
    checkCollisionAgainst(ground)
    processMovement(delta)
    speed.add(acceleration.cpy().scl(delta))
    position.add(speed.cpy().scl(delta))
  }

  def checkCollisionAgainst(ground: Ground) {
    rectangle.checkCollision(ground.rectangle).foreach(_ => {
      stopFalling
    })
  }

  def processMovement(delta: Float) {
    if (Gdx.input.isKeyPressed(Keys.RIGHT)) {
      speed.add(200, 0)
    }
    if (Gdx.input.isKeyPressed(Keys.LEFT)) {
      speed.add(-200, 0)
    }
  }

  def stopFalling {
    speed = new Vector2(0, 0)
    acceleration = new Vector2(0, 0)
  }
}
