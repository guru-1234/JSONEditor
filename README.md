# Game Object Instatiater Using JSON Data

Game object instantiater tool is used to dynamically generate gameobject with a custom heirarchal strucutre 
and can save the structure as JSON in a desired Path user need. Also read and load the pre-exist JSON data.

# How to Use the Insatntiater Tool #

## Generate JSON Data ##
   * Create a template for your heirarchial structure with 'RootParent' class in inspector 
   * Feed the desired path in 'Path To Save JSON' field
   * Feed the file name to be in thr 'File Name To Save'
   * Click 'Generate JSON Data' button to generate a JSON file in the desired path
     ![HowToUse](https://github.com/guru-1234/JSONEditor/assets/59476943/19581298-7306-4104-b7b9-a7e913067e2a)
  * Required warning will be shown if required fields are empty
    ![warning1](https://github.com/guru-1234/JSONEditor/assets/59476943/ab0eabfd-4c85-40c1-85bb-4dc227e5fd8e)
  ### Limitations ###
  * First time storing an JSON will be slow to reflect back to the unity editor, there would be delay

## Editing an JSON as String and Storing it ##
   * Put the JSON file inside 'JSON File To Read' 
   * Click the toggle button 'Edit JSON as String'
   * That will popsup a 'JSON As text' field
   * JSON will be shown in that field with JSON indent format, can modify
   * Click the 'Save Data From JSON String' button, it will reflect the data to file itself![button1](https://github.com/guru-1234/JSONEditor/assets/59476943/578d8140-e8d9-401a-8020-57f51b56cb5e)
     ![EditAstring2](https://github.com/guru-1234/JSONEditor/assets/59476943/2c3e880d-614e-4203-92a7-5aff8adcb9d7)

  * Required warning will be shown if data is not presented and Storing will Validate Json
    ![warning2](https://github.com/guru-1234/JSONEditor/assets/59476943/de48bb71-2745-4f7f-8dd8-bc7a4ae4478d)
    ![JSonNotValid](https://github.com/guru-1234/JSONEditor/assets/59476943/730ddf3c-80f0-4b41-9e65-6265d84e47f0)
    ![JSONIsValid](https://github.com/guru-1234/JSONEditor/assets/59476943/c272be72-53ce-4214-99a6-643f347c60e1)


  ### Limitations ###
  * This way of storing only reflect in the JSON file, not on 'Root Parent' Class template
  * Have to Click 'Load & Read JSON Data' button to reflect on it

## Dynamically creating Gameobjects ##
   * Just can click the 'Create Game Object' button, if the previous steps are being correctly followed 
   * Just check if you have pre-defined prefab in the follwing path in the same name also
       * Assets/Prefabs/TestPefab
         
        ![Prefabs](https://github.com/guru-1234/JSONEditor/assets/59476943/b9f95dfe-d252-40d9-b229-fbe038b5b3dd)
 
   * Will Create gameobjects in the current scene with all active objects
   ![Heirarchy2](https://github.com/guru-1234/JSONEditor/assets/59476943/929ae0ee-0466-44c8-8d82-badf431cac20)

 * Required components and parameters for the componets will be enabled through JSON data, if it mentioned
  ### Limitations ###
  * If parent name is 'null', it create object without a parent object
  * Had to have unique gameobjects name
## Buttons ##
![buttons2](https://github.com/guru-1234/JSONEditor/assets/59476943/6e06e5a6-777a-4582-8d9a-4bcce6c09263)

## Inspector Tab ##
![Inspector2](https://github.com/guru-1234/JSONEditor/assets/59476943/29d6425f-bac4-4224-99d9-0167c895ecaa)

## Sample JSON Data ##
![StoragePath](https://github.com/guru-1234/JSONEditor/assets/59476943/6d3df7fa-04f8-48c6-bc0f-5d0fcede884f)
