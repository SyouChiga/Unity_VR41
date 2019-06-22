using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
namespace VRGAME
{
    namespace Editor
    {
        public class ObjectPut : EditorWindow
        {
            //置くオブジェクト
            public GameObject objPut_;
            //軸指定
            public bool xAxiz_, yAxiz_, zAxiz_;
            //間隔数値
            public Vector3 intervalPut_;
            //置く数
            public int countPut_;
            //ウィンドウ作成
            [MenuItem("Editor/ObjectPut")]
            public static void Create()
            {
                // 生成
                ObjectPut window = GetWindow< ObjectPut>("オブジェクトプット");

                window.minSize = new Vector2(320, 320);
            }

            private void OnGUI()
            {
                objPut_ = (GameObject)Selection.activeObject;
                EditorGUILayout.ObjectField(objPut_, typeof(GameObject), false);

                GUIUpdate();

                if (GUILayout.Button("設定"))
                {
                    if (objPut_ != null) Put();
                }
            }

            void GUIUpdate()
            {
                EditorGUILayout.BeginHorizontal();
                xAxiz_ = GUILayout.Toggle(xAxiz_, "X");
                yAxiz_ = GUILayout.Toggle(yAxiz_, "Y");
                zAxiz_ = GUILayout.Toggle(zAxiz_, "Z");
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("X間隔:");
                intervalPut_.x = EditorGUILayout.FloatField(intervalPut_.x);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Y間隔:");
                intervalPut_.y = EditorGUILayout.FloatField(intervalPut_.y);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Z間隔:");
                intervalPut_.z = EditorGUILayout.FloatField(intervalPut_.z);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("置く数");
                countPut_ = EditorGUILayout.IntField(countPut_);
                EditorGUILayout.EndHorizontal();

            }

            //置く処理
            private void Put()
            {
                if (xAxiz_) PutFix(new Vector3(intervalPut_.x, 0.0f, 0.0f));
                if (yAxiz_) PutFix(new Vector3(0.0f, intervalPut_.y, 0.0f));
                if (zAxiz_) PutFix(new Vector3(0.0f, 0.0f, intervalPut_.z));
            }

            private void PutFix(Vector3 put)
            {
                Vector3 originPos = objPut_.transform.position;

                Vector3 plus = new Vector3(originPos.x + (1.0f * put.x), originPos.y + (1.0f * put.y), originPos.z + (1.0f * put.z));
                Vector3 minus = new Vector3(originPos.x + (-1.0f * put.x), originPos.y + (-1.0f * put.y), originPos.z + (-1.0f * put.z));
                for (int i = 0; i < countPut_; i++)
                {
                    Instantiate(objPut_, plus,  objPut_.transform.rotation);
                    Instantiate(objPut_, minus, objPut_.transform.rotation);

                    plus = new Vector3(plus.x + (1.0f * put.x), plus.y + (1.0f * put.y), plus.z + (1.0f * put.z));
                    minus = new Vector3(minus.x + (-1.0f * put.x), minus.y + (-1.0f * put.y), minus.z + (-1.0f * put.z));
                }
            }
        }
    }
}
#endif
