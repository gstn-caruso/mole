package com.gaston

import ar.com.pablitar.libgdx.commons.rendering.Renderers
import com.badlogic.gdx.graphics.glutils.ShapeRenderer.ShapeType
import com.badlogic.gdx.{ApplicationAdapter, Gdx}
import com.gaston.character.Player
import com.gaston.scenario.Ground

class Mole extends ApplicationAdapter {

	val player = new Player
	val ground = new Ground
	lazy val renderers = new Renderers

	override def render () {
		update(Gdx.graphics.getDeltaTime)
		renderWorld()
	}

	override def dispose() {
		renderers.dispose()
	}

	def update(delta: Float) {
		player.update(delta, ground)
	}

	def renderWorld() {
		renderers.withRenderCycle((0.1f,0.1f,0.1f)) {
			renderers.withShapes(ShapeType.Filled) { shapeRenderer =>
				shapeRenderer.rect(ground.topLeft.x, ground.topLeft.y, ground.width, ground.height)
				shapeRenderer.rect(player.topLeft.x, player.topLeft.y, player.width, player.height)
			}
		}
	}
}
