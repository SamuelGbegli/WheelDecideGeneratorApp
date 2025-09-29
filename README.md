# WheelDecideGeneratorApp

## Overview

This is a desktop application made with Windows Presentation Framework (WPF), designed to easily create content to use for the site Wheel Decide ([https://wheeldecide.com/](https://wheeldecide.com/)).



Instructions on using the application can be found in the section "How to use the application".

## Licencing notes

This application uses components from the Extended WPF Toolkit by Xceed ([https://github.com/xceedsoftware/wpftoolkit](https://github.com/xceedsoftware/wpftoolkit)), specifically controls for numeric and colour input. I am using Extended WPF Toolkit under Xceed's Community Licence, which prohibits commercial use of the components, so this application will remain free to view and download.

## Background

I have been using Wheel Decide for years as a way to choose from a large set of values, and I've found manually configuring and setting up wheels to be sometimes tedious, usually when creating many custom and intrecate wheels in a short period of time. My goal for this project is to simplify the wheel creation process with a graphical user interface (useful for setting segment and text colours), as well as allowing the user to copy the wheel's URL and values to use immediately.

## Features

* A grid to add, edit and remove wheel segments
* A multiplier to determine how many times each segment will appear on the wheel
* A toggle to shuffle the positions of the wheel's segments (including duplicates)
* A dialog to copy the wheel segments' values, colours and weights (relative proportional size)

## How to use the application

The executable file can be found in this location in the repository:



WheelDecideGeneratorApp\\bin\\Release\\net9.0-windows\\WheelDecideGeneratorApp.exe



Below is an overview of the application's controls and functions:



* Clicking "Add" will create a new segment value, which will appear in the grid. Up to 100 segments can be created as this is the maximum allowed by Wheel Decide.
* Clicking "Remove selected" will remove the currently selected values from the grid.
* Clicking "Remove all" will clear all values from the grid.
* A segment's properties can be edited by clicking on a row's cells in the grid. Values that can be edited are value (text input), background colour and text colour (colour dropdown/input) and weight (decimal value between 0.1 and 10 inclusive, in increments of 0.1).
* The segment multiplier value will duplicate the number of segments that will appear on the wheel. The minimum value is 1 (i.e., each segment will appear once) and the maximum is set to how many times the current set of values can be multiplied before exceeding 100.
* The "Shuffle wheel segments on generation" randomly changes the positon of the wheel's segments prior to generation. The positions will vary every time the wheel's data is generated.
* The "Generate" button will open a dialog showing the values that can be copied directly to Wheel Decide. A URL is also provided to directly access the wheel from the site.

### Output dialog

When the "Generate" button is clicked, a dialog will open with the following values:

* Values (formatted with line breaks)
* Background colours (formatted with commas)
* Text colours (formatted with commas)
* Weights (formatted with commas)
* A URL to access the wheel directly



Each value can be selected and manually copied to be used.

## Future plans

This is still a work in progress, and I have listed a roadmap of tasks I plan to do in the future:

* Expand the application to create full wheels, including options to set the wheel's title, spin duration, diameter and whether a segment is removed from the wheel once selected
* The ability to save and load wheel designs, possibly via JSON
* Buttons in the output dialog to more easily copy the wheel's link to the clipboard
* Data validation to ensure values are not blank or white space
