using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace DBracket.Common.UI.WPF.Sample
{
    internal class ToDelete
    {
        
//    <!--<Color x:Key="BorderMediumColor">Green</Color>
//    --><!--<Color x:Key="BorderMediumColor">#FF888888</Color>--><!--
//    <Color x:Key="BorderDarkColor">Purple</Color>
//    --><!--<Color x:Key="BorderDarkColor">#FF444444</Color>--><!--

//    <Color x:Key="ControlLightColor">Red</Color>
//    --><!--<Color x:Key="ControlLightColor">White</Color>--><!--
//    <Color x:Key="ControlMediumColor">#FF7381F9</Color>

//    <Color x:Key="ControlPressedColor">#FF211AA9</Color>
//    <Color x:Key="DisabledForegroundColor">#FF888888</Color>
//    --><!--<Color x:Key="GlyphColor">#FF444444</Color>--><!--
//    <Color x:Key="GlyphColor">LightPink</Color>
//    --><!--<Color x:Key="BorderLightColor">#FFCCCCCC</Color>--><!--
//    <Color x:Key="BorderLightColor">Yellow</Color>-->





//    <!--<ControlTemplate x:Key="VerticalScrollBarTemplate"
//                     TargetType="{x:Type ScrollBar}">
//        <Grid>
//            <Grid.RowDefinitions>
//                <RowDefinition MaxHeight = "18" />
//                < RowDefinition Height="0.00001*" />
//                <RowDefinition MaxHeight = "18" />
//            </ Grid.RowDefinitions >
//            < Border Grid.RowSpan="3"
//                    CornerRadius="2"
//                    Background="Gray" />
//            <RepeatButton Grid.Row="0"
//                          Style= "{StaticResource ScrollBarLineButton}"
//                          Height= "18"
//                          Command= "ScrollBar.LineUpCommand"
//                          Content= "M 0 4 L 8 4 L 4 0 Z" />
//            < Track x:Name= "PART_Track"
//                   Grid.Row= "1"
//                   IsDirectionReversed= "true" >
//                < Track.DecreaseRepeatButton >
//                    < RepeatButton Style= "{StaticResource ScrollBarPageButton}"
//                                  Command= "ScrollBar.PageUpCommand" />
//                </ Track.DecreaseRepeatButton >
//                < Track.Thumb >
//                    -->< !--Style = "{StaticResource ScrollBarThumb}"-- >< !--
//                    < Thumb
//                           Margin= "1,0,1,0" >
//                        < Thumb.BorderBrush >

//                            < LinearGradientBrush StartPoint= "0,0"
//                                                 EndPoint= "1,0" >
//                                < LinearGradientBrush.GradientStops >
//                                    < GradientStopCollection >
//                                        < GradientStop Color= "{DynamicResource BorderLightColor}"
//                                                      Offset= "0.0" />
//                                        < GradientStop Color= "{DynamicResource BorderDarkColor}"
//                                                      Offset= "1.0" />
//                                    </ GradientStopCollection >
//                                </ LinearGradientBrush.GradientStops >
//                            </ LinearGradientBrush >

//                        </ Thumb.BorderBrush >
//                        < Thumb.Background >

//                            < LinearGradientBrush StartPoint= "0,0"
//                                                 EndPoint= "1,0" >
//                                < LinearGradientBrush.GradientStops >
//                                    < GradientStopCollection >
//                                        < GradientStop Color= "{DynamicResource ControlLightColor}"
//                                                      Offset= "0.0" />
//                                        < GradientStop Color= "{DynamicResource ControlMediumColor}"
//                                                      Offset= "1.0" />
//                                    </ GradientStopCollection >
//                                </ LinearGradientBrush.GradientStops >
//                            </ LinearGradientBrush >

//                        </ Thumb.Background >

//                        < Thumb.Style >
//                            < Style TargetType= "Thumb"
//                                   BasedOn= "{StaticResource ScrollBarThumb}" >
//                                < Setter Property= "Width"
//                                        Value= "10" />
//                                < Style.Triggers >
//                                    < Trigger Property= "IsMouseOver"
//                                             Value= "True" >
//                                        < Setter Property= "Width"
//                                                Value= "20" />
//                                    </ Trigger >
//                                </ Style.Triggers >
//                            </ Style >
//                        </ Thumb.Style >
//                    </ Thumb >
//                </ Track.Thumb >
//                < Track.IncreaseRepeatButton >
//                    < RepeatButton Style= "{StaticResource ScrollBarPageButton}"
//                                  Command= "ScrollBar.PageDownCommand" />
//                </ Track.IncreaseRepeatButton >
//            </ Track >
//            < RepeatButton Grid.Row= "2"
//                          Style= "{StaticResource ScrollBarLineButton}"
//                          Height= "18"
//                          Command= "ScrollBar.LineDownCommand"
//                          Content= "M 0 0 L 4 4 L 8 0 Z" />
//        </ Grid >
//        < ControlTemplate.Triggers >
//            < Trigger Property= "IsMouseOver"
//                     Value= "True" >
//                < Setter Property= "Width"
//                        Value= "18" />
//            </ Trigger >
//        </ ControlTemplate.Triggers >
//    </ ControlTemplate > -->

//    < !--< ControlTemplate x:Key= "HorizontalScrollBar"
//                     TargetType= "{x:Type ScrollBar}" >
//        < Grid >
//            < Grid.ColumnDefinitions >
//                < ColumnDefinition MaxWidth= "18" />
//                < ColumnDefinition Width= "0.00001*" />
//                < ColumnDefinition MaxWidth= "18" />
//            </ Grid.ColumnDefinitions >
//            < Border Grid.ColumnSpan= "3"
//                    CornerRadius= "2"
//                    Background= "#F0F0F0" />
//            < RepeatButton Grid.Column= "0"
//                          Style= "{StaticResource ScrollBarLineButton}"
//                          Width= "18"
//                          Command= "ScrollBar.LineLeftCommand"
//                          Content= "M 4 0 L 4 8 L 0 4 Z" />
//            < Track x:Name= "PART_Track"
//                   Grid.Column= "1"
//                   IsDirectionReversed= "False" >
//                < Track.DecreaseRepeatButton >
//                    < RepeatButton Style= "{StaticResource ScrollBarPageButton}"
//                                  Command= "ScrollBar.PageLeftCommand" />
//                </ Track.DecreaseRepeatButton >
//                < Track.Thumb >
//                    < Thumb Style= "{StaticResource ScrollBarThumb}"
//                           Margin= "0,1,0,1" >

//                        < Thumb.BorderBrush >

//                            < LinearGradientBrush StartPoint= "0,0"
//                                                 EndPoint= "1,0" >
//                                < LinearGradientBrush.GradientStops >
//                                    < GradientStopCollection >
//                                        < GradientStop Color= "{DynamicResource BorderLightColor}"
//                                                      Offset= "0.0" />
//                                        < GradientStop Color= "{DynamicResource BorderDarkColor}"
//                                                      Offset= "1.0" />
//                                    </ GradientStopCollection >
//                                </ LinearGradientBrush.GradientStops >
//                            </ LinearGradientBrush >

//                        </ Thumb.BorderBrush >
//                        < Thumb.Background >

//                            < LinearGradientBrush StartPoint= "0,0"
//                                                 EndPoint= "0,1" >
//                                < LinearGradientBrush.GradientStops >
//                                    < GradientStopCollection >
//                                        < GradientStop Color= "{DynamicResource ControlLightColor}"
//                                                      Offset= "0.0" />
//                                        < GradientStop Color= "{DynamicResource ControlMediumColor}"
//                                                      Offset= "1.0" />
//                                    </ GradientStopCollection >
//                                </ LinearGradientBrush.GradientStops >
//                            </ LinearGradientBrush >

//                        </ Thumb.Background >
//                    </ Thumb >
//                </ Track.Thumb >
//                < Track.IncreaseRepeatButton >
//                    < RepeatButton Style= "{StaticResource ScrollBarPageButton}"
//                                  Command= "ScrollBar.PageRightCommand" />
//                </ Track.IncreaseRepeatButton >
//            </ Track >
//            < RepeatButton Grid.Column= "2"
//                          Style= "{StaticResource ScrollBarLineButton}"
//                          Width= "18"
//                          Command= "ScrollBar.LineRightCommand"
//                          Content= "M 0 0 L 4 4 L 0 8 Z" />
//        </ Grid >
//    </ ControlTemplate > -->

//    < !--< Style x:Key= "VerticalScrollBar"
//           TargetType= "{x:Type ScrollBar}" >
//        < Setter Property= "SnapsToDevicePixels"
//                Value= "True" />
//        < Setter Property= "OverridesDefaultStyle"
//                Value= "true" />
//        < Setter Property= "Template"
//                Value= "{StaticResource VerticalScrollBarTemplate}" />
//        < Setter Property= "Width"
//                Value= "10" />
//        < Setter Property= "Height"
//                Value= "Auto" />
//        < Style.Triggers >
//            -->< !--< Trigger Property= "Orientation"
//                     Value= "Horizontal" >
//                < Setter Property= "Width"
//                        Value= "Auto" />
//                < Setter Property= "Height"
//                        Value= "18" />
//                < Setter Property= "Template"
//                        Value= "{StaticResource HorizontalScrollBar}" />
//            </ Trigger >
//            < Trigger Property= "Orientation"
//                     Value= "Vertical" >
//                < Setter Property= "Width"
//                        Value= "10" />
//                < Setter Property= "Height"
//                        Value= "Auto" />
//                < Setter Property= "Template"
//                        Value= "{StaticResource VerticalScrollBar}" />
//            </ Trigger > -->

//            < !--< MultiTrigger >
//                < MultiTrigger.Conditions >
//                    < Condition Property= "Orientation"
//                               Value= "Vertical" />
//                    < Condition Property= "IsMouseOver"
//                               Value= "False" />
//                </ MultiTrigger.Conditions >
//                < MultiTrigger.Setters >
//                    < Setter Property= "Width"
//                            Value= "10" />
//                    < Setter Property= "Height"
//                            Value= "Auto" />
//                    < Setter Property= "Template"
//                            Value= "{StaticResource VerticalScrollBar}" />
//                </ MultiTrigger.Setters >
//            </ MultiTrigger >

//            < MultiTrigger >
//                < MultiTrigger.Conditions >
//                    < Condition Property= "Orientation"
//                               Value= "Vertical" />
//                    < Condition Property= "IsMouseOver"
//                               Value= "True" />
//                </ MultiTrigger.Conditions >
//                < MultiTrigger.Setters >
//                    < Setter Property= "Width"
//                            Value= "18" />
//                    < Setter Property= "Height"
//                            Value= "Auto" />
//                    < Setter Property= "Template"
//                            Value= "{StaticResource VerticalScrollBar}" />
//                </ MultiTrigger.Setters >
//            </ MultiTrigger > -->< !--
//        </ Style.Triggers >
//    </ Style > -->

//    < !--< Style x:Key= "{x:Type ScrollBar}"
//           TargetType= "{x:Type ScrollBar}" >
//        < Setter Property= "SnapsToDevicePixels"
//                Value= "True" />
//        < Setter Property= "OverridesDefaultStyle"
//                Value= "true" />
//        < Style.Triggers >
//            < Trigger Property= "Orientation"
//                     Value= "Horizontal" >
//                < Setter Property= "Width"
//                        Value= "Auto" />
//                < Setter Property= "Height"
//                        Value= "18" />
//                < Setter Property= "Template"
//                        Value= "{StaticResource HorizontalScrollBar}" />
//            </ Trigger >
//            < Trigger Property= "Orientation"
//                     Value= "Vertical" >
//                < Setter Property= "Width"
//                        Value= "10" />
//                < Setter Property= "Height"
//                        Value= "Auto" />
//                -->< !--< Setter Property= "Template"
//                        Value= "{StaticResource VerticalScrollBar}" /> -->< !--
//            </ Trigger >

//            -->< !--< MultiTrigger >
//                < MultiTrigger.Conditions >
//                    < Condition Property= "Orientation"
//                               Value= "Vertical" />
//                    < Condition Property= "IsMouseOver"
//                               Value= "False" />
//                </ MultiTrigger.Conditions >
//                < MultiTrigger.Setters >
//                    < Setter Property= "Width"
//                            Value= "10" />
//                    < Setter Property= "Height"
//                            Value= "Auto" />
//                    < Setter Property= "Template"
//                            Value= "{StaticResource VerticalScrollBar}" />
//                </ MultiTrigger.Setters >
//            </ MultiTrigger >

//            < MultiTrigger >
//                < MultiTrigger.Conditions >
//                    < Condition Property= "Orientation"
//                               Value= "Vertical" />
//                    < Condition Property= "IsMouseOver"
//                               Value= "True" />
//                </ MultiTrigger.Conditions >
//                < MultiTrigger.Setters >
//                    < Setter Property= "Width"
//                            Value= "18" />
//                    < Setter Property= "Height"
//                            Value= "Auto" />
//                    < Setter Property= "Template"
//                            Value= "{StaticResource VerticalScrollBar}" />
//                </ MultiTrigger.Setters >
//            </ MultiTrigger > -->< !--
//        </ Style.Triggers >
//    </ Style > -->

//    < !--< Style x:Key= "ScrollBarLineButton"
//       TargetType= "{x:Type controls:RepeatButton}" >
//    < Setter Property= "SnapsToDevicePixels"
//            Value= "True" />
//    < Setter Property= "OverridesDefaultStyle"
//            Value= "True" />
//    < Setter Property= "Focusable"
//            Value= "False" />
//    < Setter Property= "Template" >
//        < Setter.Value >
//            < ControlTemplate TargetType= "{x:Type controls:RepeatButton}" >
//                < Border x:Name= "PART_Root"
//                        Background= "{TemplateBinding Background}"
//                        BorderBrush= "{TemplateBinding BorderBrush}"
//                        BorderThickness= "{TemplateBinding BorderThickness}"
//                        Padding= "{TemplateBinding Padding}"
//                        CornerRadius= "{TemplateBinding CornerRadius}" >
//                    < ContentPresenter x:Name= "PART_ContentHost"
//                                      HorizontalAlignment= "Center" />
//                </ Border >
//                -->
//    < !--< ControlTemplate.Triggers >
//                    < Trigger Property= "IsMouseOver"
//                             Value= "True" >
//                        < Setter Property= "Background"
//                                Value= "Green" />
//                    </ Trigger >
//                </ ControlTemplate.Triggers > -->
//    < !--
//            </ ControlTemplate >
//        </ Setter.Value >
//    </ Setter >
//</ Style > -->


    }
}