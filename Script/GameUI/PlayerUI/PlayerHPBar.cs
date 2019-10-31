using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameNumType;
// 角色血条
/**  2019-10-31 lemon
脚本绑定给父canvas
血条由三张图片组成,分别代表:
    1.血条框
    2.血条背景(下层血量或透明)
    3.血量


 */
public class PlayerHPBar: MonoBehaviour
{
    private string typeHp = AtomType.TypeName; // 血量类型,KWNumType(KW) or KNumType(K) or AtomNumType(Atom)
    private ANumType HPNum = new AtomType(100); // 总血量
    private ANumType currentHPNum = new AtomType(50); // 当前血量
    
    private int HPLayer = 1; // 总血条层数
    private int currentHPLayer = 1; // 当前血量层数 
    private int currentHPLayerNum = HPNum * 1f * currentHPLayer / HPLayer; // 当前血量层血量

    public PlayerHPBar()
    {

    }



    public void UpHPBar()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
