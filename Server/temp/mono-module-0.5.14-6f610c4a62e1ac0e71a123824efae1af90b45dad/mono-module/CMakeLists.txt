cmake_minimum_required(VERSION 3.0)
project(mono-module)

set(CMAKE_CXX_STANDARD 11)
add_definitions(-std=c++11)

file(GLOB SOURCE_FILES
    "${CMAKE_CURRENT_SOURCE_DIR}/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp"
	"${CMAKE_CURRENT_SOURCE_DIR}/Mono/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/Mono/*.cpp"
	"${CMAKE_CURRENT_SOURCE_DIR}/API/*.h"
    "${CMAKE_CURRENT_SOURCE_DIR}/API/*.cpp"
)

add_library(mono-module SHARED ${SOURCE_FILES})

set_target_properties(mono-module PROPERTIES PREFIX "lib")
set_target_properties(mono-module PROPERTIES LIBRARY_OUTPUT_DIRECTORY ${PROJECT_BINARY_DIR})

include_directories(/usr/include/mono-2.0/)
target_link_libraries(mono-module -lmono-2.0)