# MEA Cruncher

<p align="center">
  <img src="https://raw.github.com/Rabadash8820/MEA-Cruncher/master/Solution/Resources/Mea.png" alt="MEA Cruncher icon"/>
</p>

## Overview

This application is intended to replace the hodge podge of Excel macros that have accumulated during my data analysis work with Dr. Jordan Renna in the University of Akron Biology Department.
Rather than writing documentation to help he and his lab navigate all of those spreadsheets, dictating the file names and directory structures that they should use, and requring them to manually open third party softwares like
Offline Sorter and NeuroExplorer as part of the process, I figured I would just write an application to make the pipeline more automatic and user-friendly.

Moreover, this project represents a sort of culmination of my understing of Visual C#, WinForms, Git source control and GitHub, the .NET framework, NHiberate, NuGet, InstallShield, MySQL, and more.  My hope is that this project will serve as proof of my knowledge of these technologies to future software companies, even though my formal eduction is in biology.

## Latest Release - v0.1.0

The latest version of MEA Cruncher will always be available for download on my [personal webpage](http://dan-vicarel.com/).
You can also download the source and build it yourself in (only tested in Visual Studio 2013).

**Note that MEA Cruncher is currently in development.  It should be considered unstable and likely to change, significantly and frequently.**

I will use Semantic Versioning to number future releases.  This versioning system is described [here](http://semver.org/). 

## License

I have not yet selected a license for this software.

## Developer Notes

All content under this heading is for my personal reference during the development process.

### To-do list for New Entity Forms

* __Control Names__
	* MainTableLayout
	* BottomPanel
	* CreateButton
	* CancelCreateButton
	* Property fields, e.g., TitleLabel and TitleTextbox
* __Control Properties__
	* MainTableLayout bottom row Absolute, property rows Autosize, Comments row Percent rest
	* Form 
		* Text : Create New [Entity]
		* MinimizeBox : False
		* MaximizeBox : False
		* ShowIcon : False
		* ShowInTaskbar : False
		* AcceptButton : CreateButton
		* CancelButton : CancelCreateButton
		* StartPosition : CenterParent
		* Appropriate MinimumSize (all controls and most of their content visible, comment textboxes still larger than others)
		* Appropriate Tab Order (for labels, TabStop : False)
	* All controls, GenerateMember : True
	* CreateButton and CancelCreateButton
		* AutoSize : True
		* FlatStyle : Flat
	* Textboxes
		* BorderStyle : FixedSingle
		* MaxLength same as in MySQL db
	* DateTimePickers, MinDate : 1/1/1970 
* __Control Settings__
	* All controls, Font : ControlFont
	* Form, BackColor : FormBackColor
	* Labels, ForeColor : LabelForeColor
	* Textboxes
		* ForeColor : TextboxForeColor
		* BackColor : TextBoxBackColor
	* Buttons
		* ForeColor : ButtonForeColor
		* BackColor : ButtonBackColor
* __Changes in Code__
	* DateTimePickers have MaximumValue = DateTime.Now
	* MainTableLayout's bottom row, Size.Height = Settings.Default.ContainerHeight
	* Textboxes
		* Size.Height = Settings.Default.ControlHeight
		* Provide default values from Resource strings

### To-do list for View Entitites Forms

* __Control Names__
	* MainTableLayout
	* BottomPanel
	* NewButton
	* EditButton
	* DeleteButton
	* CloseButton
	* EntitiesDGV
	* Property fields, e.g., TitleColumn
* __Control Properties__
	* MainTableLayout bottom row Absolute, top row Percent 100%
	* Form 
		* Text : [Entities]
		* MinimizeBox : False
		* MaximizeBox : True
		* ShowIcon : True
		* ShowInTaskbar : False
		* AcceptButton : None
		* CancelButton : CloseButton
		* StartPosition : WindowsDefaultLocation
		* Appropriate MinimumSize (all buttons and DGV columns visible, a couple rows visible, height 150 seems to look good)
		* Appropriate Tab Order (for DGV, TabStop : True)
	* All controls, GenerateMember : True
	* Buttons
		* AutoSize : True
		* FlatStyle : Flat
	* EntitiesDGV
		* Headers
			* ColumnHeadersBorderStyle : Single
			* ColumnHeadersHeightSizeMode : AutoSize
			* EnableHeadersVisualStyles : False
			* RowHeadersVisible : False
		* Columns
			* AutoSizeMode : None
			* For short columns with all content about same length, AutoSize : AllCells
			* Last column, AutoSize : Fill
			* MaxInputLength same as in MySQL db
		* Selecting
			* MultiSelect : False
			* SelectionMode : FullRowSelect
		* BorderStyle : None
		* TabStop : True
		* DateTimePickers, MinDate : 1/1/1970 
* __Control Settings__
	* All controls, Font : ControlFont
	* Form, BackColor : FormBackColor
	* Buttons
		* ForeColor : ButtonForeColor
		* BackColor : ButtonBackColor
	* EntitiesDGV
		* BackgroundColor : DgvBackColor
		* GridColor : DgvGridColor
* __Changes in Code__
	* MainTableLayout's bottom row, Size.Height = Settings.Default.ContainerHeight
	* EntitiesDVH
		* DefaultCellStyle.BackColor = Settings.Default.DgvCellBackColor;
        * DefaultCellStyle.ForeColor = Settings.Default.DgvCellForeColor;
        * ColumnHeadersDefaultCellStyle.BackColor = Settings.Default.DgvHeaderBackColor;
        * ColumnHeadersDefaultCellStyle.ForeColor = Settings.Default.DgvHeaderForeColor;
