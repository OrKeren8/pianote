library ieee;
use ieee.std_logic_1164.all;
use ieee.std_logic_unsigned.all;
use ieee.std_logic_arith.all;
use work.notes.all;
use work.Melodies.all;

entity vga_control is
port(pixel_row,pixel_column : in std_logic_vector(9 downto 0);
	sel		:in std_logic_vector(0 to 2);
	clock : in std_logic ;
	gpio : in std_logic_vector(6 downto 0);
	gpioControl : in std_logic;
	Y      :out std_logic_vector(2 downto 0));
end entity;

architecture arch_vga_control of vga_control is
signal music : matrix;
signal Cmelody : matrix := keta0;
begin
process (pixel_row,pixel_column)
variable z: std_logic_vector (6 downto 0);
variable bit1color :std_logic;
variable i : integer := 0;
begin


if sel="000" then 
		music<=Cmelody;
	elsif sel="001" then 
		music<=keta1;
	elsif sel="010" then 
		music<=keta2;
	elsif sel="011" then 
		music<=keta3;
		elsif sel="100" then 
		music<=keta4;
	elsif sel="101" then 
		music<=keta5;
	elsif sel="110" then 
		music<=keta6;
		elsif sel="111" then 
		music<=keta7;
end if;

--print notes on screen control by row and column:
--i := 0;
for r in 0 to 5 loop			--r=row, there are 5 rows.
	for c in 0 to 39 loop	--c=column, there are 40 columns.
		if pixel_row >= (64*r) and pixel_row < (64*(r+1)) then 				--check row
			if pixel_column >= (16*c) and pixel_column < (16*(c+1)) then	--check column
					z:= music(r*40+c); 	--print music of current row and column
			else 
				y<="111";
			end if;
		end if;	
	end loop;
end loop;

--end of print notes on screen control

bit1color := not (notesALL(   conv_integer(z)    )(conv_integer(pixel_row(5 downto 0))*16 + conv_integer(pixel_column(3 downto 0))));	
	y <= (bit1color & bit1color & bit1color);
end process;

process(clock)
	variable ketaIndex : integer := 0;
	variable accept : std_logic := '0';
	begin
		if rising_edge(clock) then
			if gpioControl = '1' and accept='0' then
				accept :='1';
				--read gpio
				if gpio = "0000001" then --reset word
					Cmelody <= keta0;
					ketaIndex := 0;
				else
					for n in 0 to 255 loop
						if Cmelody(n)="0000001" then 
							ketaIndex:=n;
							exit;
						end if;
					end loop;
					if Cmelody(ketaIndex) = "0000001" then
						Cmelody(ketaIndex) <= gpio;
					end if;
				end if;
				--increment index anyways
				ketaIndex := ketaIndex + 1;			
			elsif gpioControl = '0' and accept='1' then
				accept :='0';
			end if;
				
--				if gpio = "0000010" then 
--					accept := '1';
--				elsif accept = '1' then
--					if gpio = "0000001" then
--						Cmelody <= keta0;
--						ketaIndex := 0;
--						accept := '0';					
--					else
--						if Cmelody(ketaIndex) = "0000001" then 
--							Cmelody(ketaIndex) <= gpio;
--						end if;
--						ketaIndex := ketaIndex + 1;
--					end if;
--					--elsif Cmelody(ketaIndex) = "0000001" then 
--						--Cmelody(ketaIndex) <= gpio;
--						--ketaIndex := ketaIndex + 1;
--					--end if;
--					accept := '0';
				--end if;			
		end if;
	end process;
end architecture;