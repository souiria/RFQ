# SEWSE.Commercial.SalesSystem

# Check for files every x seconds
# When file found perform validation
#	Check extension is csv
#	Check file is not duplicate name
# Read all file data
# Convert file data into file upload model
# Check for duplicate data
# Any validation problems, move file to error folder
# Check for empty customer number
# Save valid data to EdiFileDataUpload table
# Save duplicate data to EdiFileDataUploadDuplicates table
# Send email alert about duplicates
# Move file into archive folder.

# Select all outstanding rows from Edi Invoice Information table
# Check for valid prices
#	If price found, set status to heldup
#	If no price found, check if ZeroPrices are allowed
#		If allowed, set price to zero and status to held up
#		If not allowed, set price to -1 and status to missing price

# For each dispatch, check if the product exists in Unit4
#	If not, add part to unit4
#	If yes, and has valid price, flad as valid dispatch row
# Check if full dispatch is valid
#	If no, log and report error
#	If yes, save data into Edi Unit 4 table and remove from edi invoice information

# Load data from Edi Invoice Unit 4 table where the data has been sent but not confirmed
# Match against data in Unit4
# If found, set status to validated
# Finish process
