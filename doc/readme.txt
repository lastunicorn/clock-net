AnalogClock v2.0 alpha2
=======================

The AnalogClock is a .net control that displays an old style analog clock.

Table of Contents
-----------------

I) The code design - Quick look
	1) The action - System.Windows.Forms.Timer object
	2) The data - ITimeProvider interface
	3) The appearance - IShape interface
II) Design Time Support
III) The Shape Sets
IV) Developping a new shape
V) Using the clock
VI) Features


I) The code design - Quick look
-------------------------------

In short words:
- The action is performed by a timer.
- The data is provided by an ITimeProvider.
- The appearance is controlled with IShape objects.


	a) The action - System.Windows.Forms.Timer object
	-------------------------------------------------

	The AnalogClock's value can be set in two ways:
	1) manually by specifying the TimeSpan value to be displayed. The value is static and it will not be changed until you specify a new one;
	2) automatically by a System.Windows.Forms.Timer object that updates the displayed value periodically. The timer is using the TimeSpan value obtained from the ITimeProvider object.
	The timer will update the control with the value obtainedd from the time provider.


	b) The data - ITimeProvider interface
	-------------------------------------

	The sole purpose of the ITimeProvider interface is to provide a TimeSpan object when someone requests it.
	AnanlogClock comes with three implementations of the ITimeProvider interface:
		- LocalTimeProvider - Returns the system's local time.
		- UtcTimeProvider - Returns the UTC time.
		- UtcOffsetTimeProvider - Returns the UTC time to which an offset is added.


	c) The appearance - IShape interface
	------------------------------------

	When it comes to the visual part, the clock is highly customizable. The hands, the numbers, the ticks that mark the seconds on the side of the clock, all are drawn by IShape objects and not directly by the clock. Therefore, if you want, you can replace the default ISahpe instances that handle the respecitive visual elements with some custom implementations that draws them as you need. For example you can replace the hands that, by default, are vectorial shapes, with some images. This is done with an ImageHandShape object (that also implements IShape interface). A demo project can be found in the release package. Check the "Clock Examples" form, tab "Fancy", first clock.


II) Design Time Support
-----------------------

All the shapes's properties and the time provider's properties have design time support. But the shapes and the time provider themselves can not be replaced from the design. This will be implemented in a future version. For now, the only way to replace the shapes and the time provider is from the code. Sorry for the inconvenience.


III) The Shape Sets
-------------------

You have two methods to change the way the clock looks:
1) Use the default shapes and change their parameters.
2) Replace one or all of the shapes with custom ones.

A ShapeSet object is a collection of IShape instances that are applied all at once. The same efect you can obtain by setting the shapes one by one.


IV) Developping a new shape
---------------------------

The shapes are drawn for a clock with diameter of 100px. The clock will scale them as needed.

To create a new shape you need to do the folowing steps:
1) Create a new class that either implements the IShape interface or it extends one of the already existing base classes. For example ShapeBase or VectorialShapeBase.
2) Overwrite the Name property. This is not so important, but is nice to have a descriptive name for the shape.
3) Overwrite the Draw method. This is the method that actually draws the shape on the control. You can imagine this one is pretty important. ;)

Obs: You may want to overwrite the Dispose method, too, to clean the memory of the tools used in the drawing process. (Only if iu use same own declared tools that needs clean up.)


V) Using the clock
------------------

On short:
1) Add the AnalogClock control to the Toolbox.
2) Drag a new AnalogClock control on your form.
3) Attach a Timer to the clock.

With more details:
1) Add the AnalogClock control to the Toolbox.
	a) Right click inside the Toolbox and choose "Add Tab" from the context menu. Name the newly created tab "Clock" (or any other name).
	b) Right click inside the "Clock" tab. Choose "Choose Items..." from the context menu.
	c) In the new dialog, on the ".Net Framework Components" click the "Browse..." button and open the "ClockNet.dll" file that you downloaded.
	Now you should heve in the Toolbox's tab, the "AnalogClock" control.
2) Drag from the Toolbox a new "AnalogClock" control on your form.
3) Drag from the ToolBox on your form a new "Timer". It can be found in the "Components" tab. Set the Interval value and enable it from the "Properties" tool window.
4) Select the "AnalogClock" added on your form. In the "Properties" tool window find the "Timer" property and set it to use the timer created in step 3.
5) Additionally you may change the properties of the default shapes of the "AnalogClock" in "Properties" tool window in the "Shapes" category.

Congratualtions! You have a working clock that displays the current system time.

For advanced configurations, like changing the shapes with custom ones or using a different time provider, you need to write some code. (Hopefully some tutorials will be included in a later version. :D )


VI) Features
------------

- Customizable appearance. (Using IShape objects.)
- Decoupled design. The actor (that updates the control), tha data (that is displayed) and the view (the way the clock looks) are decoupled.
- Scalable.
- Easy to use.
