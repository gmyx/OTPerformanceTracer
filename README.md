# Experimental tool to analyse opentext thread log files

## impleted features
* load a sigle file
* load a folder
* highlight long running requets (currenlty fixed at 10+ seconds)
* rudementry exclude filter, basicly a * something * search. stored in HKCU\OTPerftrace\Filters
* all files are loaded async using tasks

## potential features
* configuration options (change highlight color, time required, fonts, etc)
* deconstruct performance tracer when present (OT assoc value)
* reduce memory footprint (all files are fully loaded into memory)
* monitor threads as they are written
