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
import { SpaceSystem, Waypoint, WaypointType } from './space-traders-types.mjs';
import { CreatePlane } from '@babylonjs/core/Meshes/Builders/planeBuilder';
import { Mesh } from '@babylonjs/core/Meshes/mesh';
import { AdvancedDynamicTexture } from '@babylonjs/gui/2D/advancedDynamicTexture';
import { TextBlock } from '@babylonjs/gui/2D/controls/textBlock';
import { PointLight } from '@babylonjs/core/Lights/pointLight';

let scene: Scene | undefined;

export function initialize(canvas: HTMLCanvasElement) {
    new ResizeObserver(() => {
        canvas.width = canvas.offsetWidth;
    }).observe(canvas);

    const engine = new Engine(canvas);
    scene = new Scene(engine);
    scene.clearColor = new Color4(0, 0, 0, 1);

    const camera = new ArcRotateCamera('camera1', 0, .8, 100, Vector3.Zero(), scene);
    camera.lowerRadiusLimit = 10;
    camera.panningInertia = .96;
    camera.panningSensibility = 100;
    camera.mapPanning = true;
    camera.attachControl(true, false, 0);

    const gridMaterial = new GridMaterial('grid', scene);
    gridMaterial.opacity = 0.2;
    gridMaterial.mainColor = new Color3(.5, .5, .5);
    gridMaterial.lineColor = new Color3(1, 1, 1);
    gridMaterial.backFaceCulling = false;
    gridMaterial.fogEnabled = true;

    const ground = CreateGround('ground1', { width: 1000, height: 1000, subdivisions: 0 }, scene);
    ground.material = gridMaterial;

    const skyboxMaterial = new StandardMaterial("skyBox", scene);
    skyboxMaterial.backFaceCulling = false;
    skyboxMaterial.disableLighting = true;
    skyboxMaterial.reflectionTexture = new CubeTexture("/images/skyboxes/blue2/", scene);
    skyboxMaterial.reflectionTexture.coordinatesMode = Texture.SKYBOX_MODE;
    skyboxMaterial.alpha = .2;
    const skybox = CreateBox("skyBox", { size: 1000.0 }, scene);
    skybox.material = skyboxMaterial;
    skybox.infiniteDistance = true;

    const light = new PointLight("pointLight", Vector3.Zero(), scene);
    light.intensity += 1;

    engine.runRenderLoop(() => {
        scene?.render();
    });
}

export function setWaypoints(waypoints: Waypoint[] = []) {
    const orbitalLocations = new Map<string, number>();

    for (const waypoint of waypoints) {
        let offset = 10;
        for (const orbital of waypoint.orbitals) {
            orbitalLocations.set(orbital.symbol, offset);
            offset += 10;
        }
    }

    for (const waypoint of waypoints) {
        const waypointMaterial = new StandardMaterial("waypointMaterial", scene);
        waypointMaterial.diffuseColor = getWaypointColor(waypoint.type);

        const waypointMesh = CreateSphere('sphere1', { segments: 16, diameter: getWaypointSize(waypoint.type) }, scene);
        waypointMesh.position = new Vector3(
            waypoint.x * 3,
            2 + (orbitalLocations.get(waypoint.symbol) ?? 0),
            waypoint.y * 3
        );
        waypointMesh.material = waypointMaterial;

        const labelPlane = CreatePlane("plane", { size: 50 });
        labelPlane.billboardMode = Mesh.BILLBOARDMODE_ALL;
        labelPlane.position.y = 2;
        labelPlane.parent = waypointMesh;

        const labelTexture = AdvancedDynamicTexture.CreateForMesh(labelPlane);
        const labelTextBlock = new TextBlock();
        labelTextBlock.text = `${WaypointType[waypoint.type]} ${waypoint.symbol}`;
        labelTextBlock.color = "white";
        labelTextBlock.fontSize = "50"
        labelTexture.addControl(labelTextBlock);
    }
}

function getWaypointSize(type: WaypointType) {
    switch (type) {
        case WaypointType.Planet:
            return 3;
        case WaypointType.GasGiant:
            return 4;
        case WaypointType.Moon:
            return 2;
        case WaypointType.OrbitalStation:
            return 1;
        case WaypointType.JumpGate:
            return 1;
        case WaypointType.AsteroidField:
            return 2;
        case WaypointType.Nebula:
            return 3;
        case WaypointType.DebrisField:
            return 1;
        case WaypointType.GravityWell:
            return 5;
    };
}

function getWaypointColor(type: WaypointType) {
    switch (type) {
        case WaypointType.Planet:
            return new Color3(0, 1, 0.5); // greeny blue
        case WaypointType.GasGiant:
            return new Color3(0.6, 0.2, 0.4); // pinky
        case WaypointType.Moon:
            return new Color3(1, 1, 1); // white
        case WaypointType.OrbitalStation:
            return new Color3(0.2, 0.2, 0.2); // dark gray
        case WaypointType.JumpGate:
            return new Color3(1, 0.5, 0); // orange
        case WaypointType.AsteroidField:
            return new Color3(0.4, 0.4, 0.4); // dark gray
        case WaypointType.Nebula:
            return new Color3(0.7, 0.7, 1); // light blue
        case WaypointType.DebrisField:
            return new Color3(1, 1, 0); // yellow
        case WaypointType.GravityWell:
            return new Color3(1, 0, 1); // magenta
    }
}