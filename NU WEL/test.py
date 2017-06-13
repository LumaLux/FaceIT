#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Jun  8 14:56:09 2017

@author: franktieck
"""

import face_recognition
import os

def facecheck(datetime):
    folder = "./Processed/" + datetime
    for filename in os.listdir(folder):
        if os.path.isfile(folder +"/"+ filename):
            test1 = 0
            
            frank_image = face_recognition.load_image_file(folder +"/"+ filename)
            
            try:
                frank_face_encoding = face_recognition.face_encodings(frank_image)[0]
                test1 = 1
            except IndexError:
                os.remove(folder +"/"+ filename)
                print(filename + " has no face")
                     
            if test1 == 1:
                for filename2 in os.listdir(folder):
                    if os.path.isfile(folder +"/"+ filename2):
                        if filename != filename2:
                            test2 = 0
                            unknown_image = face_recognition.load_image_file(folder +"/"+ filename2)
                            try:
                                unknown_face_encoding = face_recognition.face_encodings(unknown_image)[0]
                                test2 = 1
                            except IndexError:
                                os.remove(folder +"/"+ filename2)
                                print(filename2 + " has no face")
                                
                            if test2 ==1:
                                known_faces = [
                                    frank_face_encoding
                                ]
                                    
                                results = face_recognition.compare_faces(known_faces, unknown_face_encoding)
                                
                                if results[0]:
                                    os.remove(folder +"/"+ filename2)
                                    print(filename2 + " face is already known")