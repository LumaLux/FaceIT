#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Jun  8 14:56:09 2017

@author: franktieck
"""

import face_recognition

# Load the jpg files into numpy arrays
robin_image = face_recognition.load_image_file("67.png")
frank_image = face_recognition.load_image_file("99.png")
niels_image = face_recognition.load_image_file("75.png")
unknown_image = face_recognition.load_image_file("70.png")

# Get the face encodings for each face in each image file
# Since there could be more than one face in each image, it returns a list of encordings.
# But since I know each image only has one face, I only care about the first encoding in each image, so I grab index 0.
robin_face_encoding = face_recognition.face_encodings(robin_image)[0]
frank_face_encoding = face_recognition.face_encodings(frank_image)[0]
niels_face_encoding = face_recognition.face_encodings(niels_image)[0]
unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]

known_faces = [
	robin_face_encoding,
	frank_face_encoding,
	niels_face_encoding
]

# results is an array of True/False telling if the unknown face matched anyone in the known_faces array
results = face_recognition.compare_faces(known_faces, unknown_face_encoding)

print("Is the unknown face a picture of robin? {}".format(results[0]))
print("Is the unknown face a picture of frank? {}".format(results[1]))
print("Is the unknown face a picture of niels? {}".format(results[2]))
print("Is the unknown face a new person that we've never seen before? {}".format(not True in results))
