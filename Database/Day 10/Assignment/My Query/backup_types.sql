backup database ITI
to disk = 'D:\ITI\Database\MyBackupData'

backup database ITI
to disk = 'D:\ITI\Database\MyBackupData'
with differential

backup log ITI
to disk = 'D:\ITI\Database\MyBackupData'

restore database ITI
from disk = 'D:\ITI\Database\MyBackupData'
with replace --replace old database and restore new

