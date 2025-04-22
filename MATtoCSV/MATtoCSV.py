import scipy.io
import pandas as pd
import numpy as np
import os
import sys

def save_array_to_csv(array, name, output_dir):
    # Handle 2D numeric arrays
    if isinstance(array, np.ndarray):
        if array.ndim == 2:
            df = pd.DataFrame(array)
            csv_path = os.path.join(output_dir, f"{name}.csv")
            df.to_csv(csv_path, index=False)
            print(f"Saved 2D array '{name}' to {csv_path}")
        elif array.ndim == 1:
            print(f"Skipped '{name}': 1D array with shape {array.shape}")
            # Optional: uncomment to save 1D arrays as single-column CSVs
            # df = pd.DataFrame(array)
            # csv_path = os.path.join(output_dir, f"{name}.csv")
            # df.to_csv(csv_path, index=False)
        elif array.ndim == 0:
            print(f"Skipped '{name}': scalar or empty")
        else:
            print(f"Skipped '{name}': array with {array.ndim} dimensions")
    else:
        print(f"Skipped '{name}': unsupported type {type(array)}")

def mat_to_csv_all(mat_file_path, output_dir=None):
    # Load .mat file
    mat_data = scipy.io.loadmat(mat_file_path, struct_as_record=False, squeeze_me=True)

    # Set output directory
    if output_dir is None:
        output_dir = os.path.splitext(mat_file_path)[0] + '_csv'
    os.makedirs(output_dir, exist_ok=True)

    for key, value in mat_data.items():
        if key.startswith('__'):
            continue

        # If it's a struct, recursively handle fields
        if isinstance(value, scipy.io.matlab.mio5_params.mat_struct):
            for field in value._fieldnames:
                field_value = getattr(value, field)
                save_array_to_csv(field_value, f"{key}_{field}", output_dir)

        # Handle regular arrays
        elif isinstance(value, np.ndarray):
            save_array_to_csv(value, key, output_dir)

        else:
            print(f"Skipped '{key}': unsupported type {type(value)}")

if __name__ == '__main__':
    if len(sys.argv) < 2:
        print("Usage: python mat_to_csv_all.py <file.mat> [output_dir]")
    else:
        mat_file = sys.argv[1]
        output_folder = sys.argv[2] if len(sys.argv) > 2 else None
        mat_to_csv_all(mat_file, output_folder)
