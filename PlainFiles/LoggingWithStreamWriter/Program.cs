﻿using LoggingWithStreamWriter;

using (var logger = new LogWriter("log.txt"))
{
    logger.WriteLog("INFO", "Application starded.");
    logger.WriteLog("ERROR", "An unexpecter error occurred.");
    logger.WriteLog("INFO", "Application finished.");

}
