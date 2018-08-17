using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using QAI;


/// <summary> A blackboard node for a variable of GameObject type.</summary>
[CreateNodeMenu("Blackboard/GameObject")]
public class BlackboardGameObject : BlackboardVariableNode<GameObject> {}