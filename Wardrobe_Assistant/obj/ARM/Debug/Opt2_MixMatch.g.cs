﻿#pragma checksum "C:\Users\Meg_94\Documents\Visual Studio 2015\Projects\Wardrobe_AssistantFinal2\Wardrobe_Assistant\Wardrobe_Assistant\Opt2_MixMatch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "319BC13C7F0B10E517131243CE09B440"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wardrobe_Assistant
{
    partial class Opt2_MixMatch : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.listView1 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\Opt2_MixMatch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Explore_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.AddDress = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\Opt2_MixMatch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddDress).Click += this.AddDress_Click;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\Opt2_MixMatch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.MixMatch_Click;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 18 "..\..\..\Opt2_MixMatch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.MyCollections_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.textBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.textBlock2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.flipViewtop = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 10:
                {
                    this.flipViewbottom = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 11:
                {
                    this.button1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 47 "..\..\..\Opt2_MixMatch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button1).Click += this.button1_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
