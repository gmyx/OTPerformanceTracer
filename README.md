# Experimental tool to analyse opentext thread log files

## impleted features
* load a sigle file
* load a folder
* highlight long running requets (currenlty fixed at 10+ seconds)
* rudementry exclude filter, basicly a * something * search. stored in HKCU\OTPerftrace\Filters
* rudementry exclude thread filters, allowing to exclude some threads 
* all files are loaded async using tasks
* recent files / recent folders

## potential features
* configuration options (change highlight color, time required, fonts, etc)
* deconstruct performance tracer when present (OT assoc value)
* reduce memory footprint (all files are fully loaded into memory)
* monitor threads as they are written
* tag logs for note taking (e.g. say this log is important)
* search logs
* better filters (e.g. regex)

## changes to do
* there is some code from the main form that should be in a class instead, such as initiating the loading of files
