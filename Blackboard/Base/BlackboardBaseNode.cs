using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace QAI {

  /// <summary>A base class for nodes that provide blackboard data to other nodes.</summary>
  [CreateNodeMenu("")]
  [NodeTint("#FFBABB")]
  public abstract class BlackboardBaseNode : Node {

    /// <summary>The current value of the blackboard variable.</summary>
    public abstract object GetValue();
  }
}