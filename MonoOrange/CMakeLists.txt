cmake_minimum_required(VERSION 3.0)
project(MonoOrange)

set(CMAKE_CXX_STANDARD 11)
add_definitions(-std=c++11)

file(GLOB SOURCE_FILES
    "${CMAKE_CURRENT_SOURCE_DIR}/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp"
)

add_library(MonoOrange SHARED ${SOURCE_FILES})

set_target_properties(MonoOrange PROPERTIES PREFIX "")
set_target_properties(MonoOrange PROPERTIES LIBRARY_OUTPUT_DIRECTORY ${PROJECT_BINARY_DIR})

include_directories(/usr/include/mono-2.0/)
target_link_libraries(MonoOrange -lmono-2.0)