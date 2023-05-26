# MailingSystem
This solutions consists of multiple projects.

 - MailingSystem.Producer is a library which provides Producer class responsible for estabilishng connection with rabbitmq queue and sending messages to this queue.
 - MailingSystem.Model is a library which stores model classes used by MailingSystem.Producer and MailingSystem.Consumer
 - MailingSystem.Consumer is a console application responsible for consuming messages sent to rabbitmq queue. 
This project also is responsible for sending messages through MailingSystem (currently only fake ones).
 - MailingSystem is a console application which uses MailingSystem.Producer library for connection with rabbitmq and every 3 seconds sends a request to queue.

Request consists of Mail which we want to send and name of service that we want to be used for sending this email.

 - GUSDataViewer is a project which retrives data from GUS API and prints them in grid.

