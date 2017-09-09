package com.gaston.character

import ar.com.pablitar.libgdx.commons.traits.RectangularPositioned
import com.badlogic.gdx.math.Vector2

class Player extends RectangularPositioned {
    position = new Vector2(10, 300)
    override val width = 15f
    override val height = 80f
    val speed = new Vector2(0, 0)
    val acceleration = new Vector2(0, -150)

    def update(delta: Float) = {
        this.speed.add(this.acceleration.cpy().scl(delta))
        this.position.add(this.speed.cpy().scl(delta))
    }
}
