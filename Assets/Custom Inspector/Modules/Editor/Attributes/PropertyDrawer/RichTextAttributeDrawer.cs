using CustomInspector.Extensions;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CustomInspector.Editor
{
    [CustomPropertyDrawer(typeof(RichTextAttribute))]
    public class RichTextAttributeDrawer : PropertyDrawer
    {
        const float toggleWidth = 17;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                DrawProperties.DrawPropertyWithMessage(position, label, property, $"{nameof(RichTextAttribute)} only valid on strings.", MessageType.Error);
                return;
            }


            RichTextAttribute a = (RichTextAttribute)attribute;
            //string[] lines = (a.allowMultipleLines == false) ? new string[] { property.stringValue } : property.stringValue.Split('\n');

            Rect labelRect = new(position)
            {
                width = EditorGUIUtility.labelWidth,
                height = EditorGUIUtility.singleLineHeight,
            };
            if (label.text == "")
            {
                labelRect.width = Mathf.Clamp(18 - position.x, 0, 18); //label only takes space if no space in front of
            }


            Rect infoRect = new(position)
            {
                height = EditorGUIUtility.singleLineHeight
            };
            infoRect.y = position.y + position.height - infoRect.height - EditorGUIUtility.standardVerticalSpacing;


            Rect textRect = new()
            {
                x = labelRect.x + labelRect.width + 2,
                y = position.y,
                width = position.width - labelRect.width,
                height = position.height,
            };
            if (property.isExpanded) //draw info
                textRect.height = position.height - (infoRect.height + EditorGUIUtility.standardVerticalSpacing);

            property.isExpanded = EditorGUI.Foldout(labelRect, property.isExpanded, label);

            GUIStyle style = new(GUI.skin.textField)
            {
                richText = !property.isExpanded
            };
            using (new NewIndentLevel(0))
            {
                EditorGUI.BeginChangeCheck();
                string res = EditorGUI.TextField(textRect, property.stringValue, style);
                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = res;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }

            if (property.isExpanded)
            {
                using (new EditorGUI.IndentLevelScope(1))
                    property.isExpanded = !EditorGUI.Toggle(infoRect, new GUIContent("Use Rich text", "Richttext is currently disabled for this textfield. Click the toggle to active it."), !property.isExpanded);
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
                return DrawProperties.GetPropertyWithMessageHeight(label, property);

            RichTextAttribute a = (RichTextAttribute)attribute;
            GUIStyle style = new(GUI.skin.textField)
            {
                richText = !property.isExpanded
            };

            float height;
            if (a.allowMultipleLines)
            {
                height = style.CalcSize(new GUIContent(property.stringValue)).y;
            }
            else
            {
                string firstLine = new string(property.stringValue.TakeWhile(c => c != '\n').ToArray());
                height = style.CalcSize(new GUIContent(firstLine)).y;
            }

            if (property.isExpanded)
                height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            return height;
        }
    }
}
