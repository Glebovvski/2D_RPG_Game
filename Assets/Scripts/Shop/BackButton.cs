﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

    private void OnMouseDown()
    {
        NavigationManager.GoBack();
    }
}
