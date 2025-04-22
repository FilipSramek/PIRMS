data = load('data.mat');

% If you know the variable name, e.g., data.myVariable
csvwrite('output.csv', data.Data1_AI_2_vibrace_hlava);  % For simple numeric matrices

% Or for newer versions:
writematrix(data.myVariable, 'output.csv');
