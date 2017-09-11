package com.gaston.character

import ar.com.pablitar.libgdx.commons.extensions.ShapeExtensions._
import ar.com.pablitar.libgdx.commons.traits.{RectangularPositioned, SpeedBehaviour}
import com.badlogic.gdx.Gdx
import com.badlogic.gdx.Input.Keys
import com.badlogic.gdx.math.Vector2
import com.gaston.scenario.Ground

class Player extends RectangularPositioned with SpeedBehaviour {
  val basePlayerSpeedMagnitude = 800
  val gravity = new Vector2(0, -5)
  position = new Vector2(10, 300)
  var velocity = new Vector2()
  var jump = false
  var canJump = true
  var standOnGround = true

  override val width = 15f
  override val height = 80f
  var acceleration = new Vector2(0, -250f)

  def update(delta: Float, ground: Ground) = {
    velocity.add(gravity)
    processMovement(delta)
    speed.add(acceleration.cpy().scl(delta))
    position.add(speed.cpy().scl(delta))
    checkCollisionAgainst(ground)

    //    position.add(velocity)
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
    if (Gdx.input.isKeyPressed(Keys.UP)) {
      if (jump && canJump) { // Add an upward velocity
        velocity.add(0, 20)
        // Disallow jumping, so you can't jump in mid air.
        canJump = false
      }
    }
    if (standOnGround) { // You can't fall down when you stand on a ground
      velocity.y = 0
      // When you stand on a ground you can jump again
      canJump = true
    }
    if (velocity.y < -20) velocity.y = -20

  }

  def stopFalling {
    standOnGround = true
    speed = new Vector2(0, 0)
    acceleration = new Vector2(0, 0)
    canJump = true
    velocity.y = 0

  }
}
