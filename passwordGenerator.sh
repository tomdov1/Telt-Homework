#!/bin/bash
# Check if at least one username:password pair is provided
if [ $# -lt 1 ]; then
    echo "Usage: $0 username1:password1 [username2:password2 ...]"
    echo "Example: $0 alice:oldpass123 bob:secret456"
    exit 1
fi

# Output file in the current directory
OUTPUT_FILE="updated_passwords.txt"

# Function to generate random password
generate_password() 
{
    tr -dc 'A-Za-z0-9!@#$%^&*()_+=' < /dev/urandom | head -c 16
}

# Clear output file if it exists
> "$OUTPUT_FILE"

echo "Generated new passwords:"

# Process each username:password argument
for pair in "$@"; do

    username="${pair%%:*}"
    oldpassword="${pair#*:}"

    if [ -z "$username" ]; then
        echo "Warning: Skipping entry with empty username"
        continue
    fi

    new_password=$(generate_password)
    echo "$username : $new_password"
    echo "$username $new_password" >> "$OUTPUT_FILE"
done

echo "Done. Passwords written to: $OUTPUT_FILE"