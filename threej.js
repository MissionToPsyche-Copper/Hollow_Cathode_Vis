import * as THREE from './three.js-master/build/three.module.js'
import {GLTFLoader} from './three.js-master/examples/jsm/loaders/GLTFLoader.js'

// import * as THREE from 'https://unpkg.com/three/build/three.module.js';
// import { OrbitControls } from 'https://unpkg.com/three@0.127.0/examples/jsm/controls/OrbitControls.js';
// import { GLTFLoader } from 'https://unpkg.com/three@0.127.0/examples/jsm/loaders/GLTFLoader.js';

const canvas = document.querySelector('.webgl')
const scene = new THREE.Scene()

//This is where we load the glb file
const loader = new GLTFLoader()
loader.load('assets/HollowCathode.gltf', function(glb) {
    console.log(glb)
    var model = glb.scene;
    model.scale.set(0.1,0.2,0.1)

    const mesh = model.children[ 3 ];

    scene.add(model);
    gltf.animations;
    gltf.scene;
    gltf.scenes;
    gltf.cameras;
    gltf.asset;

}, function(xhr){
    console.log((xhr.loaded/xhr.total * 100) + "% loaded")
}, function(error) {    //If does not get loaded correctly
    console.log('An error occurred')
})


const light = new THREE.PointLight(0xffffff, 2, 500)
light.position.set(4.5, 10, 4.5)
scene.add(light)

// const geometry = new THREE.BoxGeometry(1,1,1)
// const material = new THREE.MeshBasicMaterial({
//     color: 0x00ff00
// })
// const boxMesh = new THREE.Mesh(geometry,material)
// scene.add(boxMesh)

//Boiler Plate Code
const sizes = {
    width: window.innerWidth,
    height: window.innerHeight
}


const camera = new THREE.PerspectiveCamera(75, sizes.width/sizes.height, 0.05, 10)
//const controls = new OrbitControls(camera, renderer.domElement );
camera.position.set(0,1,2)
scene.add(camera)


const renderer = new THREE.WebGL1Renderer({
    canvas: canvas
    
})

renderer.setSize(sizes.width, sizes.height)
document.body.appendChild( renderer.domElement);
renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2))
renderer.shadowMap.enabled = true
renderer.gammaOutput = true



function animate() {
    requestAnimationFrame(animate)
    renderer.render(scene, camera)
}

animate()