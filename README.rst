MetaMaster
==========

Small C# utility for displaying contents of MetaStock data index files
(MASTER, EMASTER, XMASTER) and exporting stock codes.

**How it works and what it does** *(I think)*

* Click the "Browse..." button.
* Navigate to a directory containing stock market data in MetaStock format.
* Select an index file.
* Click one of the enabled buttons to bring up a dialog that displays the contents of the index file.
* To export all the stock symbols that index file references to a text file, right click the data table and select "Export".



Abandon all hope, ye who enter here
-----------------------------------

Because this involves MetaStock.  And the abominable MetaStock file
format.  And newbie C# code.

Many years ago, I started writing some code to do some things I wanted
to do with MetaStock formatted stock market data, without using MetaStock,
because MetaStock was a `constant disappointment to me. 
<http://www.voidynullness.net/blog/2012/01/28/hello-amibroker/>`_

I was learning C# at the time, so I used C# for no other reason than to
practice coding in C#.

I remember working on this, but don't remember how far I got.  Because it
was a while ago now.  And I have long since given up on MetaStock and
switched to the far superior AmiBroker.

Turns out I got further than I initially thought.  This is a little dialog
app for viewing the contents of MetaStock index files (i.e. MASTER,
EMASTER, XMASTER), and exporting stock codes and stock names from those
files.  Looks like that's as far as I got -- I think that's all I wanted at
the time.  This app does nothing with price data.

I dug up this code recently, and uploaded it here for safekeeping, because
I once again found myself interested in converting MetaStock data into a
saner format.

I no longer do much work with C#, and I don't even have a recent version of
Visual Studio installed anywhere convenient.  So I installed SharpDevelop,
created a new project, and imported the code.  To my utter surprise,
everything compiled and ran fine, without even a warning!  How about that?!
C# code written by a C# newbie in Visual Studio about 8 years ago on an XP
machine, compiles runs unmodified on Windows 7 using a different
development environment.  Is the fact I'm (pleasantly) surprised by that an
indication of how cynical and jaded I've become?

In any case, I don't expect I'll be doing any more work on this codebase
itself, though it might have some use as a reference.  Will see.
