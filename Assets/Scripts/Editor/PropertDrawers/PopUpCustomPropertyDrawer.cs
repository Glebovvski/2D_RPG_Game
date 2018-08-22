using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PopupAttribute))]
public class PopUpCustomPropertyDrawer : PropertyDrawer {

	PopupAttribute popUpAttribute
    {
        get { return (PopupAttribute)attribute; }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.String)
        {
            throw new UnityException("property " + property + " must be string to use with PopUpAttribute");
        }

        var popupRect = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var currentItem = property.stringValue;
        var currentIndex = popUpAttribute.value.Length - 1;
        for (; currentIndex >= 0; currentIndex--)
        {
            if (popUpAttribute.value[currentIndex] == currentItem)
                break;
        }

        int selectedIndex = EditorGUI.Popup(popupRect, currentIndex, popUpAttribute.value);
        property.stringValue = selectedIndex < 0 ? "" : popUpAttribute.value[selectedIndex];
    }
}
