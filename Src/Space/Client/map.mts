import { ArcRotateCamera } from '@babylonjs/core/Cameras/arcRotateCamera.js';
import { Engine } from '@babylonjs/core/Engines/engine.js';
import { CubeTexture } from '@babylonjs/core/Materials/Textures/cubeTexture.js';
import { Texture } from '@babylonjs/core/Materials/Textures/texture.js';
import { StandardMaterial } from '@babylonjs/core/Materials/standardMaterial.js';
import { Color3, Color4 } from '@babylonjs/core/Maths/math.color.js';
import { Vector3 } from '@babylonjs/core/Maths/math.vector.js';
import { CreateBox } from '@babylonjs/core/Meshes/Builders/boxBuilder.js';
import { CreateGround } from '@babylonjs/core/Meshes/Builders/groundBuilder.js';
import { CreateSphere } from '@babylonjs/core/Meshes/Builders/sphereBuilder.js';
import { Scene } from '@babylonjs/core/scene.js';
import { GridMaterial } from '@babylonjs/materials/grid/gridMaterial.js';

export function doTheThing(canvas: HTMLCanvasElement) {
    new ResizeObserver(() => {
        canvas.width = canvas.offsetWidth;
    }).observe(canvas);

    const engine = new Engine(canvas);
    const scene = new Scene(engine);
    scene.clearColor = new Color4(0, 0, 0, 1);

    const camera = new ArcRotateCamera('camera1', 0, 1, 10, Vector3.Zero(), scene);
    camera.radius = 30;
    camera.lowerRadiusLimit = 10;
    camera.panningInertia = .95;
    camera.panningSensibility = 100;
    camera.mapPanning = true;
    camera.attachControl(true, false, 0);

    const gridMaterial = new GridMaterial('grid', scene);
    gridMaterial.opacity = 0.2;
    gridMaterial.mainColor = new Color3(.5, .5, .5);
    gridMaterial.lineColor = new Color3(1, 1, 1);
    gridMaterial.backFaceCulling = false;
    gridMaterial.fogEnabled = true;

    const sphere = CreateSphere('sphere1', { segments: 16, diameter: 2 }, scene);
    sphere.position.y = 2;
    sphere.material = gridMaterial;

    const ground = CreateGround('ground1', { width: 1000, height: 1000, subdivisions: 0 }, scene);
    ground.material = gridMaterial;

    const skyboxMaterial = new StandardMaterial("skyBox", scene);
    skyboxMaterial.backFaceCulling = false;
    skyboxMaterial.disableLighting = true;
    skyboxMaterial.disableLighting = true;
    skyboxMaterial.reflectionTexture = new CubeTexture("/images/skyboxes/blue2/", scene);
    skyboxMaterial.reflectionTexture.coordinatesMode = Texture.SKYBOX_MODE;
    skyboxMaterial.alpha = .2;
    const skybox = CreateBox("skyBox", { size: 1000.0 }, scene);
    skybox.material = skyboxMaterial;
    skybox.infiniteDistance = true;

    engine.runRenderLoop(() => {
        scene.render();
    });
}
