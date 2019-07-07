using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	private AudioSource audio;

	// Use this for initialization
	void Start(){
		this.audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	// キューブが衝突した時に効果音を鳴らす処理
	void OnCollisionEnter2D(Collision2D other) {
		// キューブ同士の衝突か地面に衝突した時のみ効果音を鳴らす
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Ground") {
			audio.volume = 1;
			audio.Play ();
		}
	}
}